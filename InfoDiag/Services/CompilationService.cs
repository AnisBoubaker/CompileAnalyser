using AutoMapper;
using Entity;
using Microsoft.AspNetCore.Http;
using Repositories.Interfaces;
using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace Services
{
    public class CompilationService : ICompilationService
    {
        private const int LineKeep = 3;
        private IClientService _clientService;
        private ILogAnalyzerService _logAnalyzerService;
        private ICompilationRepository _compilationRepository;
        private IMapper _mapper;

        public CompilationService(
            IClientService clientService,
            ILogAnalyzerService logAnalyzerService,
            ICompilationRepository compilationRepository,
            IMapper mapper)
        {
            _clientService = clientService;
            _logAnalyzerService = logAnalyzerService;
            _compilationRepository = compilationRepository;
            _mapper = mapper;
        }

        public string AddCompilation(IFormFile file)
        {
            (var projPath, var logPath, var programPath) = ProcessZip(file);
            var clientId = _clientService.FindClientId(projPath);
            if(clientId == 0)
            {
                return "le .vcxprog doit être inclus avec la compilation";
            }

            var lines = _logAnalyzerService.MapToLines(logPath);

            AddReferenceLines(lines, programPath);

            var compilationErrors = _mapper.Map<IEnumerable<CompilationError>>(lines);

            var compilation = new Compilation
            {
                ClientId = clientId,
                CompilationErrors = compilationErrors.ToList(),
                CompilationTime = DateTime.UtcNow
            };

            _compilationRepository.Insert(compilation);

            return "Merci";
        }
        public (string projPath, string logPath, string programPath) ProcessZip(IFormFile file)
        {
            var projPath = Path.GetTempPath() + Guid.NewGuid();
            var logPath = Path.GetTempPath() + Guid.NewGuid();
            var programPath = Path.GetTempPath() + Guid.NewGuid() + "\\";

            using (var stream = file.OpenReadStream())
            using (var archive = new ZipArchive(stream))
            {
                var innerFiles = archive.Entries;
                innerFiles.Where(f => f.FullName.Contains(".vcxproj")).FirstOrDefault()?.ExtractToFile(projPath, true);
                innerFiles.Where(f => f.FullName.Contains(".log")).FirstOrDefault()?.ExtractToFile(logPath, true);
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

        public void AddReferenceLines(IEnumerable<LogLine> loglines, string directory)
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

                if (logline.Line - LineKeep > 0)
                {
                    finalChoice = lines.Skip(logline.Line - LineKeep / 2);
                }
                else
                {
                    finalChoice = lines;
                }

                logline.Lines = finalChoice.Take(LineKeep);
            }
        }
    }
}
 