namespace Entity
{
    using System.Collections.Generic;
    using Constants;

    public class Term : IBaseEntity<string>
    {
        // Should be in the format A2020
        public string Id { get; set; }

        public TermTypeEnum TermType { get; set; }

        public int Year { get; set; }

        public virtual IEnumerable<CourseGroup> CourseGroups { get; set; }
    }
}
