using System.Collections.Generic;
using Constants;

namespace Entity
{
    public class Term : IBaseEntity<string>
    {
        public string Id { get; set; }

        public string Alias { get; set; }

        public TermTypeEnum TermType { get; set; }

        public int Year { get; set; }

        public virtual IEnumerable<CourseGroup> CourseGroups { get; set; }
    }
}
