namespace Repositories
{
    using Entity;
    using Microsoft.EntityFrameworkCore;
    using Repositories.Interfaces;

    internal class ClientRepository : BaseRepository<Client, int>, IClientRepository
    {
        public ClientRepository(DbContext context)
            : base(context)
        {
        }
    }
}
