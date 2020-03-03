using System.Collections.Generic;

namespace Entity.DTO
{
    public class ErrorCategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<string> RelatedErrors { get; set; }
    }
}
