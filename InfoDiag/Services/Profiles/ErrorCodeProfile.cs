using AutoMapper;
using Data.SeedModels;
using Entity;

namespace Services.Profiles
{
    internal class ErrorCodeProfile : Profile
    {
        public ErrorCodeProfile()
        {
            CreateMap<ErrorSeedModel, ErrorCode>().ForMember(dest => dest.Description, opt => opt.MapFrom(source => source.Title));
        }
    }
}
