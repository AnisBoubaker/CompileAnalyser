namespace Repositories
{
    using Entity;
    using Microsoft.EntityFrameworkCore;
    using Repositories.Interfaces;

    internal class InstitutionRepository : BaseRepository<Institution, int>, IInstitutionRepository
    {
        public InstitutionRepository(DbContext context)
            : base(context)
        {
        }
    }
}
