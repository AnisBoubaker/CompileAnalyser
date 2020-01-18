using Constants.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTO
{
    public class StatLineDto
    {
        public int NbOccurence { get; set; }

        public string Name { get; set; }

        public bool IsErrorCode { get; set; }

        public CompilationErrorType Type { get; set; }
    }
}
