namespace Services.Interfaces
{
    using System.Collections.Generic;
    using Constants.Enums;
    using Entity.DTO;

    public interface IClientService
    {
        IEnumerable<ClientDTO> GetAllClients(string userEmail);
    }
}
