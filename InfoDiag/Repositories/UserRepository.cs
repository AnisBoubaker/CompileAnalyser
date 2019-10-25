using Entity;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories
{
    internal class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        public UserRepository(DbContext context)
           : base(context)
        {
        }
    }
}
