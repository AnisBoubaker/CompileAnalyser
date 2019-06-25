using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class ServiceCallResult<T> : ServiceCallResult
    {
        public T Value { get; set; }
    }
}
