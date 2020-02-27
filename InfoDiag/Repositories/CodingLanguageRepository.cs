namespace Repositories
{
    using Entity;
    using Microsoft.EntityFrameworkCore;
    using Repositories.Interfaces;

    internal class CodingLanguageRepository : BaseRepository<CodingLanguage, int>, ICodingLanguageRepository
    {
        public CodingLanguageRepository(DbContext context)
            : base(context)
        {
        }
    }
}
