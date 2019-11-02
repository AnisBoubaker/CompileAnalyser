namespace Entity
{
    using System.Collections.Generic;

    public class Institution : IBaseEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public virtual IEnumerable<Course> Courses { get; set; }
    }
}
