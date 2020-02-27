namespace Entity.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Constants.Enums;

    public class StatLineDto
    {
        public int NbOccurence { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public bool IsErrorCode { get; set; }

        public CompilationErrorType Type { get; set; }
    }
}
