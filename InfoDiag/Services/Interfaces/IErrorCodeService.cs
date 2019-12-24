using System.Collections.Generic;
using Entity.DTO;

namespace Services.Interfaces
{
    public interface IErrorCodeService
    {
        void SeedErrorCodes();

        IEnumerable<ErrorCodeDTO> All();
    }
}
