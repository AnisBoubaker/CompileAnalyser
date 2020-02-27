namespace Entity
{
    public class ErrorCode : IBaseEntity<string>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public int CodingLanguageId { get; set; }

        public virtual CodingLanguage CodingLanguage { get; set; }

        public int? ErrorCategoryId { get; set; }

        public virtual ErrorCategory ErrorCategory { get; set; }
    }
}
