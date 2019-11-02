namespace Repositories
{
    using Entity;
    using Microsoft.EntityFrameworkCore;
    using Repositories.Interfaces;

    internal class CourseGroupRepository : BaseRepository<CourseGroup, int>, ICourseGroupRepository
    {
        public CourseGroupRepository(DbContext context)
            : base(context)
        {
        }
    }
}
