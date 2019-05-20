using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTO
{
    public class ClientReportDTO
    {
        public ClientDTO Client { get; set; }

        public IEnumerable<CompilationErrorDTO> Errors { get; set; }


    }
}
