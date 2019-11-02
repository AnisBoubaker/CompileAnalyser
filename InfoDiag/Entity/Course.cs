namespace Entity
{
    using System.Collections.Generic;

    public class Course : IBaseEntity<string>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<CourseGroup> CourseGroups { get; set; }
    }
}
