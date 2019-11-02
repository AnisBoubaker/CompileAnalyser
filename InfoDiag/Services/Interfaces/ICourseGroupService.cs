namespace Services.Interfaces
{
    using System.Collections.Generic;
    using Entity.DTO;

    public interface ICourseGroupService
    {
        IEnumerable<CourseGroupDto> GetAll();
    }
}
