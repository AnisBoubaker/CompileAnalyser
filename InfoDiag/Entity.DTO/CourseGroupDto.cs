using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTO
{
    public class CourseGroupDto
    {
        public string Id { get; set; }

        public string CourseId { get; set; }

        public string TermId { get; set; }

        public int GroupNumber { get; set; }
    }
}
