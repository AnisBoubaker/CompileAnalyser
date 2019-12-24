using AutoMapper;
using Data.SeedModels;
using Entity;
using Entity.DTO;

namespace Services.Profiles
{
    internal class ErrorCodeProfile : Profile
    {
        public ErrorCodeProfile()
        {
            CreateMap<ErrorSeedModel, ErrorCode>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(source => source.Title))
                .ForMember(dest => dest.CodingLanguageId, opt => opt.MapFrom((src, dest, _, ctx) => ctx.Items["lang"]));
            CreateMap<ErrorCode, ErrorCodeDTO>();
        }
    }
}
