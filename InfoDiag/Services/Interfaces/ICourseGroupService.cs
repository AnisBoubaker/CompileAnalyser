using System.Collections.Generic;
using Entity.DTO;
using Services.Models;

namespace Services.Interfaces
{
    public interface ICourseGroupService
    {
        IEnumerable<CourseGroupDto> GetAll(string userEmail);

        ServiceCallResult Assign(int userId, string groupCourseId);

        ServiceCallResult AddStudent(int clientId, string groupCourseId);
    }
}
