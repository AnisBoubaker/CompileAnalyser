namespace Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Entity;
    using Entity.DTO;
    using Microsoft.EntityFrameworkCore;
    using Repositories.Interfaces;
    using Services.Interfaces;
    using Services.Models;

    internal class CourseGroupService : BaseService, ICourseGroupService
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

        public ServiceCallResult Assign(int[] userIds, string groupCourseId)
        {
            if (userIds == null)
            {
                return Error("UserIds cannot be null");
            }

            var cg = _courseGroupRepository.AllAsQueryable.Include(cg => cg.CourseGroupUsers).FirstOrDefault(cg => cg.Id == groupCourseId);

            cg.CourseGroupUsers.Clear();

            foreach (int userId in userIds)
            {
                Assign(userId, cg);
            }

            Assign(1, cg);

            _courseGroupRepository.Update(cg);

            return Success();
        }

        public ServiceCallResult<IEnumerable<CourseGroupDto>> GetAll(string userEmail)
        {
            var cgids = _userRepository.AllAsQueryable
                .Where(u => u.Email == userEmail)
                .SelectMany(u => u.CourseGroupUsers).Select(cg => cg.CourseGroupId);

            return Success(_mapper.Map<IEnumerable<CourseGroupDto>>(_courseGroupRepository.AllAsQueryable.Where(cg => cgids.Contains(cg.Id))));
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

        public ServiceCallResult<CourseGroupDto> Get(string email, string groupId)
        {
            if (_userRepository.AllAsQueryable
                .Where(u => u.Email == email)
                .SelectMany(u => u.CourseGroupUsers).Any(cgu => cgu.CourseGroupId == groupId))
            {
                return Success(_mapper.Map<CourseGroupDto>(_courseGroupRepository.Get(groupId)));
            }
            else
            {
                return Error<CourseGroupDto>("This group id doesn't exist or you don't have the rights to see it.");
            }
        }

        public ServiceCallResult CreateGroupCourse(CreateCourseGroupDto dto)
        {
            var inserted = _courseGroupRepository.Insert(new CourseGroup
            {
                TermId = dto.TermId,
                CourseId = dto.CourseId,
                GroupNumber = dto.GroupNumber,
            });

            var permited = dto.UserIds.Select(id => new CourseGroupUser { CourseGroupId = inserted.Id, UserId = id });

            // adds admin by default to every group
            permited.Concat(new[] { new CourseGroupUser { CourseGroupId = inserted.Id, UserId = 1 } });

            inserted.CourseGroupUsers = permited.ToList();

            _courseGroupRepository.Update(inserted);

            return Success();
        }

        public ServiceCallResult<IEnumerable<int>> GetPermitedUsers(string courseGroupId)
        {
            var group = _courseGroupRepository.AllAsQueryable.Where(cg => cg.Id == courseGroupId);

            var users = group.SelectMany(cg => cg.CourseGroupUsers).Select(cgu => cgu.UserId);

            return Success(users.AsEnumerable());
        }

        private void Assign(int userId, CourseGroup cg)
        {
            cg.CourseGroupUsers.Add(new CourseGroupUser
            {
                UserId = userId,
                CourseGroupId = cg.Id,
            });
        }
    }
}
