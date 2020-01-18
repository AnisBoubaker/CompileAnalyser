using Entity;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories
{
    internal class StatLineRepository : BaseRepository<StatLine, long>, IStatLineRepository
    {
        public StatLineRepository(DbContext context)
           : base(context)
        {
        }
    }
}
