using System.Collections.Generic;

namespace Entity
{
    public class Institution : IBaseEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public virtual IEnumerable<Course> Courses { get; set; }
    }
}
