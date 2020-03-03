using AutoMapper;
using Entity;
using Entity.DTO;

namespace Services.Profiles
{
    public class ErrorCategoryProfile : Profile
    {
        public ErrorCategoryProfile()
        {
            CreateMap<ErrorCategory, ErrorCategoryDto>();
        }
    }
}
