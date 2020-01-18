using System;
using System.Collections.Generic;

namespace Entity
{
    public class Stats : IBaseEntity<int>
    {
        public DateTime Date { get; set; }

        public int Id { get; set; }

        public int CompilationId { get; set; }

        public virtual Compilation Compilation { get; set; }

        public virtual ICollection<StatLine> Lines { get; set; }
    }
}
