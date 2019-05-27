namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CompilationErrorLine : IBaseEntity<int>
    {
        public int Id { get; set; }

        public string Text { get; set; }
    }
}
