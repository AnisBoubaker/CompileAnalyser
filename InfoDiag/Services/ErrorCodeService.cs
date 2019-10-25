namespace Services
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using AutoMapper;
    using Data.SeedModels;
    using Entity;
    using Entity.DTO;
    using Newtonsoft.Json;
    using Repositories.Interfaces;
    using Services.Interfaces;

    internal class ErrorCodeService : BaseService, IErrorCodeService
    {
        private readonly IErrorCodeRepository _errorCodeRepository;
        private readonly IMapper _mapper;

        public ErrorCodeService(IErrorCodeRepository errorCodeRepository, IMapper mapper)
        {
            _errorCodeRepository = errorCodeRepository;
            _mapper = mapper;
        }

        public IEnumerable<ErrorCodeDTO> All()
        {
            return _mapper.Map<IEnumerable<ErrorCodeDTO>>(_errorCodeRepository.All);
        }

        public void SeedErrorCodes()
        {
            if (_errorCodeRepository.AllAsQueryable.Any())
            {
                return;
            }

            var json = File.ReadAllText("../error.json");

            var seedData = _mapper.Map<IEnumerable<ErrorCode>>(JsonConvert.DeserializeObject<IEnumerable<ErrorSeedModel>>(json));

            var groups = seedData.GroupBy(d => d.Id).Where(g => g.Count() > 1);

            var dups = seedData.Where(e => groups.Any(g => g.Key == e.Id));

            var i = 2;
            foreach (var dup in dups)
            {
                dup.Id = dup.Id + "L" + i;
            }

            _errorCodeRepository.Insert(seedData);
        }
    }
}
