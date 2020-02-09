namespace Entity.DTO
{
    using System;
    using System.Collections.Generic;

    public class StatDto
    {
        public DateTime Date { get; set; }

        public IEnumerable<StatLineDto> Lines { get; set; }
    }
}
