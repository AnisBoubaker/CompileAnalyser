using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTO
{
    public class CreateCourseGroupDto
    {
        public string CourseId { get; set; }

        public string TermId { get; set; }

        public int GroupNumber { get; set; }

        public int[] UserIds { get; set; }
    }
}
