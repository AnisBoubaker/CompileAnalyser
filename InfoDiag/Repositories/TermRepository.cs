namespace Repositories
{
    using Entity;
    using Microsoft.EntityFrameworkCore;
    using Repositories.Interfaces;

    internal class TermRepository : BaseRepository<Term, string>, ITermRepository
    {
        public TermRepository(DbContext context)
            : base(context)
        {
        }
    }
}
