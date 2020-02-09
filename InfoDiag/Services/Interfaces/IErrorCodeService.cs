namespace Services.Interfaces
{
    using System.Collections.Generic;
    using Entity.DTO;

    public interface IErrorCodeService
    {
        void SeedErrorCodes();

        IEnumerable<ErrorCodeDTO> All();
    }
}
