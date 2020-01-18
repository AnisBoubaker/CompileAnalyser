using System;
using System.Collections.Generic;

namespace Entity.DTO
{
    public class StatDto
    {
        public DateTime Date { get; set; }

        IEnumerable<StatLineDto> Lines { get; set; }
    }
}
