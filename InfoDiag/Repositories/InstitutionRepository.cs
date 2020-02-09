namespace Repositories
{
    using System.Linq;
    using Entity;
    using Microsoft.EntityFrameworkCore;
    using Repositories.Interfaces;

    internal class InstitutionRepository : BaseRepository<Institution, int>, IInstitutionRepository
    {
        public InstitutionRepository(DbContext context)
            : base(context)
        {
        }

        public override IQueryable<Institution> AllAsQueryable => base.AllAsQueryable.Include(i => i.Courses);
    }
}
