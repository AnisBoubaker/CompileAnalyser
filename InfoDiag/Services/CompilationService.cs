namespace Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using AutoMapper;
    using Entity;
    using Microsoft.AspNetCore.Http;
    using Repositories.Interfaces;
    using Services.Interfaces;
    using Services.Models;

    public class CompilationService : BaseService, ICompilationService
    {
        private const int _lineKeep = 3;
        private readonly IVSProjAnalyzerService _clientService;
        private readonly ILogAnalyzerService _logAnalyzerService;
        private readonly ICompilationRepository _compilationRepository;
        private readonly IMapper _mapper;

        public CompilationService(
            IVSProjAnalyzerService clientService,
            ILogAnalyzerService logAnalyzerService,
            ICompilationRepository compilationRepository,
            IMapper mapper)
        {
            _clientService = clientService;
            _logAnalyzerService = logAnalyzerService;
            _compilationRepository = compilationRepository;
            _mapper = mapper;
        }

        public ServiceCallResult<string> AddCompilation(IFormFile file)
        {
            if (file == null)
            {
                return Error<string>("Une compilation doit être inclus dans cette requête");
            }

            (var projPath, var logPath, var programPath) = ProcessZip(file);
            var result = _clientService.Process(projPath);
            if (result.Failed)
            {
                return Error<string>("le .vcxprog doit être inclus avec la compilation");
            }

            var lines = _logAnalyzerService.MapToLines(logPath);

            AddReferenceLines(lines, programPath);

           //TODO : OK LA 

            var compilationErrors = _mapper.Map<IEnumerable<CompilationError>>(lines);

            var compilation = new Compilation
            {
                ClientId = result.Value,
                CompilationErrors = compilationErrors.ToList(),
                CompilationTime = DateTime.UtcNow,
            };

            _compilationRepository.Insert(compilation);

            return Success("Merci");
        }

        private (string projPath, string logPath, string programPath) ProcessZip(IFormFile file)
        {
            var projPath = Path.GetTempPath() + Guid.NewGuid();
            var logPath = Path.GetTempPath() + Guid.NewGuid();
            var programPath = Path.GetTempPath() + Guid.NewGuid() + "\\";

            using (var stream = file.OpenReadStream())
            using (var archive = new ZipArchive(stream))
            {
                var innerFiles = archive.Entries;
                innerFiles.Where(f => f.FullName.Contains(".vcxproj")).FirstOrDefault()?.ExtractToFile(projPath, true);
                using (Stream concat = File.OpenWrite(logPath))
                {
                    innerFiles.Where(f => f.FullName.Contains(".log")).ToList()
                        .ForEach(f =>
                        {
                            using var fs = f.Open();
                            fs.CopyTo(concat);
                        });
                }

                innerFiles.Where(f => f.FullName.Contains(".h") || f.FullName.Contains(".c")).ToList().ForEach(f =>
                {
                    if (!Directory.Exists(programPath))
                    {
                        Directory.CreateDirectory(programPath);
                    }

                    f.ExtractToFile(programPath.ToString() + '/' + f.Name, true);
                });
            }

            return (projPath, logPath, programPath);
        }

        private void AddReferenceLines(IEnumerable<LogLine> loglines, string directory)
        {
            var openedFiles = new Dictionary<string, string[]>();

            foreach (var logline in loglines)
            {
                if (!openedFiles.ContainsKey(logline.FileName))
                {
                    if (File.Exists(directory + logline.FileName))
                    {
                        openedFiles[logline.FileName] = File.ReadAllLines(directory + logline.FileName);
                    }
                }

                openedFiles.TryGetValue(logline.FileName, out var lines);

                if (lines == null)
                {
                    continue;
                }

                IEnumerable<string> finalChoice;

                if (logline.Line - _lineKeep > 0)
                {
                    finalChoice = lines.Skip(logline.Line - (_lineKeep / 2));
                }
                else
                {
                    finalChoice = lines;
                }

                logline.Lines = finalChoice.Take(_lineKeep);
            }
        }
    }
}
