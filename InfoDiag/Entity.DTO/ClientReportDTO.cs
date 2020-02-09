namespace Entity.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ClientReportDTO
    {
        public ClientDTO Client { get; set; }

        public IEnumerable<CompilationErrorDTO> Errors { get; set; }
    }
}
