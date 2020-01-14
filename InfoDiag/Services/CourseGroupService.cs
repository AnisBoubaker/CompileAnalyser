using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Entity.DTO;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class CourseGroupService : ICourseGroupService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICourseGroupRepository _courseGroupRepository;
        private readonly IMapper _mapper;

        public CourseGroupService(ICourseGroupRepository courseGroupRepository, IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _courseGroupRepository = courseGroupRepository;
            _mapper = mapper;
        }

        public void Assign(AssignCourseGroupDto dto)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CourseGroupDto> GetAll(string userEmail)
        {
            var cgids = _userRepository.AllAsQueryable
                .Where(u => u.Email == userEmail)
                .SelectMany(u => u.CourseGroupUsers).Select(cg => cg.CourseGroupId);

            return _mapper.Map<IEnumerable<CourseGroupDto>>(_courseGroupRepository.AllAsQueryable.Where(cg => cgids.Contains(cg.Id)));
        }
    }
}
