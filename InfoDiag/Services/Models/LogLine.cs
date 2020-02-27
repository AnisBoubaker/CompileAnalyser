namespace Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LogLine
    {
        public string FileName { get; set; }

        public int Line { get; set; }

        public string Code { get; set; }

        public string Message { get; set; }

        public string Criticity { get; set; }

        public IEnumerable<string> Lines { get; set; }
    }
}
