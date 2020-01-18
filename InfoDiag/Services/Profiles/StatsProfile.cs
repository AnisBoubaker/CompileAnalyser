using AutoMapper;
using Constants.Enums;
using Entity;
using Entity.DTO;
using System;

namespace Services.Profiles
{
    public class StatsProfile : Profile
    {
        public StatsProfile()
        {
            CreateMap<Stats, StatDto>();
            CreateMap<StatLine, StatLineDto>()
                .ForMember(dto => dto.Name, opt => opt.MapFrom(src => GetName(src)));
        }

        private string GetName(StatLine sl)
        {
            return sl.IsErrorCode ? sl.ErrorCodeId : Enum.GetName(typeof(CompilationErrorType), sl.Type);
        }
    }
}
