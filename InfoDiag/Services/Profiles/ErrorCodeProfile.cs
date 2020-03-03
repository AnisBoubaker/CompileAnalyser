namespace Services.Profiles
{
    using AutoMapper;
    using Data.SeedModels;
    using Entity;
    using Entity.DTO;

    internal class ErrorCodeProfile : Profile
    {
        public ErrorCodeProfile()
        {
            CreateMap<ErrorSeedModel, ErrorCode>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(source => source.Title))
                .ForMember(dest => dest.CodingLanguageId, opt => opt.MapFrom((src, dest, _, ctx) => ctx.Items["lang"]));
            CreateMap<ErrorCode, ErrorCodeDTO>();
            CreateMap<ErrorCode, string>().ForMember(dest => dest, opt => opt.MapFrom(src => src.Id));
        }
    }
}
