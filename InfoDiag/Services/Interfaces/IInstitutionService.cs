using Entity.DTO;
using Services.Models;

namespace Services.Interfaces
{
    public interface IInstitutionService
    {
        ServiceCallResult CreateInstitution(InstitutionDto dto);

        ServiceCallResult AddCourse(CourseDto dto);

        ServiceCallResult AddCourseGroup(CourseGroupDto dto);
    }
}
