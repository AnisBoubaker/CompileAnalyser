using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Entity;
using Entity.DTO;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Services.Interfaces;
using Services.Models;

namespace Services
{
    public class CourseGroupService : BaseService, ICourseGroupService
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

        public ServiceCallResult Assign(int userId, string groupCourseId)
        {
            var cg = _courseGroupRepository.AllAsQueryable.Include(cg => cg.CourseGroupUsers).FirstOrDefault(cg => cg.Id == groupCourseId);

            if (cg.CourseGroupUsers.Any(cgc => cgc.UserId == userId))
            {
                return Error("User is already in this group");
            }

            cg.CourseGroupUsers.Add(new CourseGroupUser
            {
                UserId = userId,
                CourseGroupId = groupCourseId,
            });

            _courseGroupRepository.Update(cg);

            return Success();
        }

        public ServiceCallResult Unassigned(int userId, string groupCourseId)
        {
            var cg = _courseGroupRepository.AllAsQueryable.Include(cg => cg.CourseGroupUsers).FirstOrDefault(cg => cg.Id == groupCourseId);

            if (!cg.CourseGroupUsers.Any(cgc => cgc.UserId == userId))
            {
                return Error("User isn't assigned to this group");
            }

            cg.CourseGroupUsers = cg.CourseGroupUsers.Where(cg => cg.UserId != userId).ToList();

            _courseGroupRepository.Update(cg);

            return Success();
        }

        public IEnumerable<CourseGroupDto> GetAll(string userEmail)
        {
            var cgids = _userRepository.AllAsQueryable
                .Where(u => u.Email == userEmail)
                .SelectMany(u => u.CourseGroupUsers).Select(cg => cg.CourseGroupId);

            return _mapper.Map<IEnumerable<CourseGroupDto>>(_courseGroupRepository.AllAsQueryable.Where(cg => cgids.Contains(cg.Id)));
        }

        public ServiceCallResult AddStudent(int clientId, string groupCourseId)
        {
            var cg = _courseGroupRepository.AllAsQueryable.Include(cg => cg.CourseGroupClients).FirstOrDefault(cg => cg.Id == groupCourseId);

            if (cg.CourseGroupClients.Any(cgc => cgc.ClientId == clientId))
            {
                return Error("Client is already in this group");
            }

            cg.CourseGroupClients.Add(new CourseGroupClient
            {
                ClientId = clientId,
                CourseGroupId = groupCourseId,
            });

            _courseGroupRepository.Update(cg);

            return Success();
        }
    }
}
