using Entity;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories
{
    internal class CompilationRepository : BaseRepository<Compilation, int>, ICompilationRepository
    {
        public CompilationRepository(DbContext context)
            : base(context)
        {
        }
    }
}
