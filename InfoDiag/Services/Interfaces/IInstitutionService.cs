using Entity.DTO;

namespace Services.Interfaces
{
    public interface IInstitutionService
    {
        bool CreateInstitution(InstitutionDto dto);

        bool AddCourse(CourseDto dto);

        bool AddCourseGroup(CourseGroupDto dto);

        bool 
    }
}
