using System.Collections.Generic;
using Constants.Enums;

namespace Entity
{
    public class CompilationError : IBaseEntity<long>
    {
        public int CompilationId { get; set; }

        public string Message { get; set; }

        public string ErrorCodeId { get; set; }

        public virtual ErrorCode ErrorCode { get; set; }

        public CompilationErrorType Type { get; set; }

        public long Id { get; set; }

        public virtual ICollection<CompilationErrorLine> Lines { get; set; }
    }
}