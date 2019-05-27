namespace Entity
{
    using System.Collections.Generic;

    public class CompilationError : IBaseEntity<long>
    {
        public int CompilationId { get; set; }

        public string Message { get; set; }

        public string Code { get; set; }

        public CompilationErrorType Type { get; set; }

        public long Id { get; set; }

        public virtual ICollection<CompilationErrorLine> Lines { get; set; }
    }
}