namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CourseGroup : IBaseEntity<string>
    {
        // This should have a format as AAA111-A2019-1
        public string Id { get; set; }

        public string CourseId { get; set; }

        public virtual Course Course { get; set; }

        public string TermId { get; set; }

        public virtual Term Term { get; set; }

        // must be positive and less then 100
        public int GroupNumber { get; set; }

        public virtual ICollection<CourseGroupClient> CourseGroupClients { get; set; }

        // don't use this in a linq query
        public IEnumerable<Client> Clients => CourseGroupClients.Select(cgc => cgc.Client);

        public virtual ICollection<CourseGroupUser> CourseGroupUsers { get; set; }

        // don't use this in a linq query
        public IEnumerable<User> Users => CourseGroupUsers.Select(cgu => cgu.User);
    }
}
