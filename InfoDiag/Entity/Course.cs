using System.Collections.Generic;

namespace Entity
{
    public class Course : IBaseEntity<string>
    {
        // Should be in the format AAA000
        public string Id { get; set; }

        public virtual IEnumerable<CourseGroup> CourseGroups { get; set; }

        public int CodingLanguageId { get; set; }

        public virtual CodingLanguage CodingLanguage { get; set; }
    }
}
