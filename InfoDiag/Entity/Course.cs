using System.Collections.Generic;

namespace Entity
{
    public class Course : IBaseEntity<string>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<CourseGroup> CourseGroups { get; set; }
    }
}
