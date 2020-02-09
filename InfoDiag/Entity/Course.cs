namespace Entity
{
    using System.Collections.Generic;

    public class Course : IBaseEntity<string>
    {
        // Should be in the format AAA000
        public string Id { get; set; }

        public virtual IEnumerable<CourseGroup> CourseGroups { get; set; }

        public int CodingLanguageId { get; set; }

        public virtual CodingLanguage CodingLanguage { get; set; }
    }
}
