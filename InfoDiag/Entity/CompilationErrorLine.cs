namespace Entity
{
    public class CompilationErrorLine : IBaseEntity<int>
    {
        public int Id { get; set; }

        public string Text { get; set; }
    }
}
