namespace Entity
{
    using System.Collections.Generic;
    using System.Linq;

    public class Client : IBaseEntity<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int Id { get; set; }

        public virtual ICollection<Compilation> Compilations { get; set; }

        public virtual ICollection<CourseGroupClient> CourseGroupClients { get; set; }

        public IEnumerable<CourseGroup> CourseGroups => CourseGroupClients.Select(cgc => cgc.CourseGroup);
    }
}
