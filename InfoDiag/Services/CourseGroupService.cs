using System.Collections.Generic;
using AutoMapper;
using Entity.DTO;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class CourseGroupService : ICourseGroupService
    {
        private readonly ICourseGroupRepository _courseGroupRepository;
        private readonly IMapper _mapper;

        public CourseGroupService(ICourseGroupRepository courseGroupRepository, IMapper mapper)
        {
            _courseGroupRepository = courseGroupRepository;
            _mapper = mapper;
        }

        public IEnumerable<CourseGroupDto> GetAll()
        {
            return _mapper.Map<IEnumerable<CourseGroupDto>>(_courseGroupRepository.All);
        }
    }
}
