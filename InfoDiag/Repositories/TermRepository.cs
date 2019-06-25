using Entity;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories
{
    internal class TermRepository : BaseRepository<Term, string>, ITermRepository
    {
        public TermRepository(DbContext context)
            : base(context)
        {
        }
    }
}
