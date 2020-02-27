namespace Services.Profiles
{
    using System;
    using System.Linq;
    using AutoMapper;
    using Constants.Enums;
    using Entity;
    using Entity.DTO;

    public class StatsProfile : Profile
    {
        public StatsProfile()
        {
            CreateMap<Stats, StatDto>();
            CreateMap<StatLine, StatLineDto>()
                .ForMember(dto => dto.Name, opt => opt.MapFrom(src => GetName(src)))
                .ForMember(dto => dto.Link, opt => opt.MapFrom(src => GetLink(src)));
            CreateMap<IGrouping<string, CompilationError>, StatLine>()
                .ForMember(dest => dest.IsErrorCode, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.ErrorCodeId, opt => opt.MapFrom(src => src.Key))
                .ForMember(dest => dest.NbOccurence, opt => opt.MapFrom(src => src.Count()))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.First().Type));
        }

        private string GetLink(StatLine src)
        {
            return src.ErrorCode?.Link;
        }

        private string GetName(StatLine sl)
        {
            return sl.IsErrorCode ? sl.ErrorCode.Description : Enum.GetName(typeof(CompilationErrorType), sl.Type);
        }
    }
}
