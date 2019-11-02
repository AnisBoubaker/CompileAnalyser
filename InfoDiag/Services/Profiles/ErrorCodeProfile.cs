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
            CreateMap<ErrorSeedModel, ErrorCode>().ForMember(dest => dest.Description, opt => opt.MapFrom(source => source.Title));
            CreateMap<ErrorCode, ErrorCodeDTO>();
        }
    }
}
