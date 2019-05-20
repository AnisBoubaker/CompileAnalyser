using System.Collections.Generic;

namespace Entity
{
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