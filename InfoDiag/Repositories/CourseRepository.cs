namespace Repositories
{
    using Entity;
    using Microsoft.EntityFrameworkCore;
    using Repositories.Interfaces;

    internal class CourseRepository : BaseRepository<Course, string>, ICourseRepository
    {
        public CourseRepository(DbContext context)
            : base(context)
        {
        }
    }
}
