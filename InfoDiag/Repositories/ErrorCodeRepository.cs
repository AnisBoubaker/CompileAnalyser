using Entity;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories
{
    internal class ErrorCodeRepository : BaseRepository<ErrorCode, string>, IErrorCodeRepository
    {
        public ErrorCodeRepository(DbContext context)
           : base(context)
        {
        }
    }
}
