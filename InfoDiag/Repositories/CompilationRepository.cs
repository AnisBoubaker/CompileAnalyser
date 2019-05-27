namespace Repositories
{
    using Entity;
    using Microsoft.EntityFrameworkCore;
    using Repositories.Interfaces;

    internal class CompilationRepository : BaseRepository<Compilation, int>, ICompilationRepository
    {
        public CompilationRepository(DbContext context)
            : base(context)
        {
        }
    }
}
