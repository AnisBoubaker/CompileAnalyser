namespace Services.Interfaces
{
    using System.Collections.Generic;
    using Entity.DTO;
    using Services.Models;

    public interface ICourseGroupService
    {
        ServiceCallResult<IEnumerable<CourseGroupDto>> GetAll(string userEmail);

        ServiceCallResult Assign(int[] userIds, string groupCourseId);

        ServiceCallResult AddStudent(int clientId, string groupCourseId);

        ServiceCallResult<CourseGroupDto> Get(string email, string groupId);

        ServiceCallResult CreateGroupCourse(CreateCourseGroupDto dto);

        ServiceCallResult<IEnumerable<int>> GetPermitedUsers(string courseGroupId);
    }
}
