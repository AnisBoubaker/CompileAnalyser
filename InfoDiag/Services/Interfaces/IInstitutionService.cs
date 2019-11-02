namespace Services.Interfaces
{
    using Entity.DTO;
    using Services.Models;

    public interface IInstitutionService
    {
        ServiceCallResult CreateInstitution(InstitutionDto dto);

        ServiceCallResult AddCourse(CourseDto dto);

        ServiceCallResult AddCourseGroup(CourseGroupDto dto);
    }
}
