using Entity;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories
{
    internal class StatsRepository : BaseRepository<Stats, int>, IStatsRepository
    {
        public StatsRepository(DbContext context)
            : base(context)
        {
        }
    }
}
