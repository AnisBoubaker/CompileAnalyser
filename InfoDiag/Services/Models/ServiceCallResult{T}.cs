namespace Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ServiceCallResult<T> : ServiceCallResult
    {
        public T Value { get; set; }
    }
}
