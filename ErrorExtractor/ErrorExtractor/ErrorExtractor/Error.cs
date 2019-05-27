namespace ErrorExtractor
{
    public class Error
    {
        public string Name { get; set; }

        public string Title { get; set; } //line 10 of page

        public string Code { get; set; }

        public string Id => Code;

        public string Link { get; set; }
    }
}
