namespace Services
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using AutoMapper;
    using Constants.Enums;
    using Data.SeedModels;
    using Entity;
    using Entity.DTO;
    using Newtonsoft.Json;
    using Repositories.Interfaces;
    using Services.Interfaces;

    internal class ErrorCodeService : BaseService, IErrorCodeService
    {
        private readonly IErrorCodeRepository _errorCodeRepository;
        private readonly ICodingLanguageRepository _codingLanguageRepository;
        private readonly IMapper _mapper;

        public ErrorCodeService(IErrorCodeRepository errorCodeRepository, ICodingLanguageRepository codingLanguageRepository, IMapper mapper)
        {
            _errorCodeRepository = errorCodeRepository;
            _codingLanguageRepository = codingLanguageRepository;
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

            SeedCPPErrors();
        }

        private void SeedCPPErrors()
        {
            var json = File.ReadAllText("../cpperror.json");

            var seedData = ProcessJson(json, CodingLanguageEnum.CPP);

            _errorCodeRepository.Insert(seedData);
        }

        private IEnumerable<ErrorCode> ProcessJson(string json, CodingLanguageEnum codingLanguage)
        {
            var lang = _codingLanguageRepository.AllAsQueryable.SingleOrDefault(cl => cl.Code == codingLanguage)?.Id;

            if (!lang.HasValue)
            {
                return null;
            }

            var jsonnr = JsonConvert.DeserializeObject<IEnumerable<ErrorSeedModel>>(json);

            return _mapper.Map<IEnumerable<ErrorCode>>(jsonnr, opt => opt.Items["lang"] = lang.Value).ToList();
        }
    }
}
