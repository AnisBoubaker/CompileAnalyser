using System.Collections.Generic;
using Constants.Enums;

namespace Entity
{
    public class CodingLanguage : IBaseEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CodingLanguageEnum Code { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<ErrorCode> ErrorCodes { get; set; }
    }
}
