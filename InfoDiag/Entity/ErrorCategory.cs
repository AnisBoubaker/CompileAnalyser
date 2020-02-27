using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class ErrorCategory : IBaseEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ErrorCode> RelatedErrors { get; set; }
    }
}
