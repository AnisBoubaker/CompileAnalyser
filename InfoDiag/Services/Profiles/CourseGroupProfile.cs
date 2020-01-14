using AutoMapper;
using Entity;
using Entity.DTO;

namespace Services.Profiles
{
    public class CourseGroupProfile : Profile
    {
        public CourseGroupProfile()
        {
            CreateMap<CourseGroup, CourseGroupDto>();
        }
    }
}
