namespace Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ServiceCallResult
    {
        public ResultType Type { get; set; }

        public string Error { get; set; }

        public bool Success => Type == ResultType.Success;

        public bool Failed => Type == ResultType.Error;
    }
}
