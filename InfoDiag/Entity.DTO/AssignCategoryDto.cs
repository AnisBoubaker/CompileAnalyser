using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTO
{
    public class AssignCategoryDto
    {
        public int CategoryId { get; set; }

        public string[] ErrorCodeIds { get; set; }
    }
}
