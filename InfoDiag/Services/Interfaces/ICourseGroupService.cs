using System.Collections.Generic;
using Entity.DTO;

namespace Services.Interfaces
{
    public interface ICourseGroupService
    {
        IEnumerable<CourseGroupDto> GetAll();

        void Assign(AssignCourseGroupDto dto);
    }
}
