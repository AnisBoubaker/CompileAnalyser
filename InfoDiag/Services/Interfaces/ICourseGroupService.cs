namespace Services.Interfaces
{
    using System.Collections.Generic;
    using Entity.DTO;
    using Services.Models;

    public interface ICourseGroupService
    {
        IEnumerable<CourseGroupDto> GetAll(string userEmail);

        ServiceCallResult Assign(int userId, string groupCourseId);

        ServiceCallResult AddStudent(int clientId, string groupCourseId);
    }
}
