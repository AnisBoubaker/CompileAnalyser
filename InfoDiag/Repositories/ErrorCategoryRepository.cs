using Entity;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories
{
    internal class ErrorCategoryRepository : BaseRepository<ErrorCategory, int>, IErrorCategoryRepository
    {
        public ErrorCategoryRepository(DbContext context)
            : base(context)
        {
        }
    }
}
