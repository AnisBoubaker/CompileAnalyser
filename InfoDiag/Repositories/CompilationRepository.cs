using Entity;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories
{
    class CompilationRepository : BaseRepository<Compilation, int>, ICompilationRepository
    {
        public CompilationRepository(DbContext context) : base(context) { }
    }
}
