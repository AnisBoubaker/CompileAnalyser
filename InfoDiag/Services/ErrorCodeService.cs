namespace Services
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using AutoMapper;
    using Data.SeedModels;
    using Entity;
    using Newtonsoft.Json;
    using Repositories.Interfaces;
    using Services.Interfaces;

    internal class ErrorCodeService : IErrorCodeService
    {
        private IErrorCodeRepository errorCodeRepository;
        private IMapper mapper;

        public ErrorCodeService(IErrorCodeRepository errorCodeRepository, IMapper mapper)
        {
            this.errorCodeRepository = errorCodeRepository;
            this.mapper = mapper;
        }

        public void SeedErrorCodes()
        {
            if (errorCodeRepository.AllAsQueryable.Any())
            {
                return;
            }

            var json = File.ReadAllText("../error.json");

            var seedData = mapper.Map<IEnumerable<ErrorCode>>(JsonConvert.DeserializeObject<IEnumerable<ErrorSeedModel>>(json));

            var groups = seedData.GroupBy(d => d.Id).Where(g => g.Count() > 1);

            //errorCodeRepository.Insert(seedData);
        }
    }
}
