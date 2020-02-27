using System.Collections.Generic;

namespace TalentMontreal.Entities
{
    public class ErrorCategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<string> RelatedErrors { get; set; }
    }
}
