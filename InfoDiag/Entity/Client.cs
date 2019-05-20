using System.Collections.Generic;

namespace Entity
{
    public class Client : IBaseEntity<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int Id { get; set; }

        public virtual ICollection<Compilation> Compilations { get; set; }
    }
}
