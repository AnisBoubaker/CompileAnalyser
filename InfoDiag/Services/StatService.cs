using AutoMapper;
using Entity.DTO;
using Repositories.Interfaces;
using Services.Interfaces;
using System.Collections.Generic;

namespace Services
{
    public class StatService : IStatService
    {
        private IStatsRepository _statsRepository;
        private IMapper _mapper;

        public StatService(IStatsRepository statsRepository, IMapper mapper)
        {
            _statsRepository = statsRepository;
            _mapper = mapper;
        }

        public IEnumerable<StatDto> Get()
        {
            return _mapper.Map<IEnumerable<StatDto>>(_statsRepository.All);
        }
    }
}
