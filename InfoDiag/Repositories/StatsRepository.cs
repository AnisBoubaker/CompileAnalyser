namespace Repositories
{
    using Entity;
    using Microsoft.EntityFrameworkCore;
    using Repositories.Interfaces;

    internal class StatsRepository : BaseRepository<Stats, long>, IStatsRepository
    {
        public StatsRepository(DbContext context)
            : base(context)
        {
        }
    }
}
