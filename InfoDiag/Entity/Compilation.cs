namespace Entity
{
    using System;
    using System.Collections.Generic;

    public class Compilation : IBaseEntity<int>
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public DateTime CompilationTime { get; set; }

        public virtual ICollection<CompilationError> CompilationErrors { get; set; }
    }
}