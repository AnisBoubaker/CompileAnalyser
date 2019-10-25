using System.Collections.Generic;
using System.Linq;

namespace Entity
{
    public class CourseGroup : IBaseEntity<int>
    {
        public int Id { get; set; }

        public string CourseId { get; set; }

        public virtual Course Course { get; set; }

        public string TermId { get; set; }

        public virtual Term Term { get; set; }

        public int GroupNumber { get; set; }

        // This should have a format as AAA111-A2019-1
        public string Alias { get; set; }

        public virtual ICollection<CourseGroupClient> CourseGroupClients { get; set; }

        public IEnumerable<Client> Clients => CourseGroupClients.Select(cgc => cgc.Client);

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
