namespace Entity
{
    using System;
    using System.Collections.Generic;

    public class Stats : IBaseEntity<long>
    {
        public DateTime Date { get; set; }

        public long Id { get; set; }

        public int CompilationId { get; set; }

        public virtual Compilation Compilation { get; set; }

        public virtual ICollection<StatLine> Lines { get; set; }
    }
}
