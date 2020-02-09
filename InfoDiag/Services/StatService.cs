namespace Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Constants.Enums;
    using Entity;
    using Entity.DTO;
    using Microsoft.EntityFrameworkCore;
    using Repositories.Interfaces;
    using Services.Interfaces;
    using Services.Models;

    public class StatService : BaseService, IStatService
    {
        private readonly IStatsRepository _statsRepository;
        private readonly ICompilationRepository _compilationRepository;
        private readonly ICourseGroupRepository _courseGroupRepository;
        private readonly IMapper _mapper;

        public StatService(
            IStatsRepository statsRepository,
            ICompilationRepository compilationRepository,
            ICourseGroupRepository courseGroupRepository,
            IMapper mapper)
        {
            _statsRepository = statsRepository;
            _compilationRepository = compilationRepository;
            _courseGroupRepository = courseGroupRepository;
            _mapper = mapper;
        }

        public ServiceCallResult<IEnumerable<StatDto>> Get(int clientId, DateTime? from = null, DateTime? to = null)
        {
            var compilationIds = _compilationRepository.AllAsQueryable.Where(c => c.ClientId == clientId).Select(c => c.Id);

            var stats = _statsRepository.AllAsQueryable.Include(s => s.Lines).Where(s => compilationIds.Contains(s.CompilationId)).ToList();

            if (from.HasValue && to.HasValue)
            {
                stats.Where(s => s.Date > from && s.Date < to);
            }

            return Success(_mapper.Map<IEnumerable<StatDto>>(stats));
        }

        public ServiceCallResult<IEnumerable<StatDto>> Get(string groupId, DateTime? from = null, DateTime? to = null)
        {
            var clientIds = _courseGroupRepository.AllAsQueryable
                .Where(cg => cg.Id == groupId)
                .SelectMany(cg => cg.CourseGroupClients)
                .Select(cgc => cgc.ClientId);

            var compilationIds = _compilationRepository.AllAsQueryable.Where(c => clientIds.Contains(c.ClientId)).Select(c => c.Id);

            var stats = _statsRepository.AllAsQueryable.Where(s => compilationIds.Contains(s.CompilationId));

            if (from.HasValue && to.HasValue)
            {
                stats.Where(s => s.Date > from && s.Date < to);
            }

            return Success(_mapper.Map<IEnumerable<StatDto>>(stats));
        }

        public void ProcessNewCompilation()
        {
            var newest = _statsRepository.AllAsQueryable.Max(s => (DateTime?)s.Date) ?? DateTime.MinValue;
            var toProcess = _compilationRepository.AllAsQueryable.Include(c => c.CompilationErrors).Where(c => c.CompilationTime > newest);
            var toInsert = toProcess.AsParallel().Select(c => Process(c));

            _statsRepository.Insert(toInsert);
        }

        private Stats Process(Compilation c)
        {
            var errorgroups = c.CompilationErrors.GroupBy(c => c.ErrorCodeId);

            var statLines = errorgroups.Select(g => _mapper.Map<StatLine>(g)).ToList();

            var types = errorgroups.GroupBy(g => g.First().Type).Select(g => new StatLine
            {
                IsErrorCode = false,
                NbOccurence = g.Sum(c => c.Count()),
                Type = g.Key,
            }).ToList();

            var stats = new Stats
            {
                CompilationId = c.Id,
                Date = DateTime.UtcNow,
                Lines = statLines.Concat(types).ToList(),
            };

            return stats;
        }
    }
}
