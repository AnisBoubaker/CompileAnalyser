namespace Services.Profiles
{
    using AutoMapper;
    using Entity;
    using Entity.DTO;

    public class CourseGroupProfile : Profile
    {
        public CourseGroupProfile()
        {
            CreateMap<CourseGroup, CourseGroupDto>();
        }
    }
}
