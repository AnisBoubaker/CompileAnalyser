using Entity;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories
{
    internal class CourseRepository : BaseRepository<Course, string>, ICourseRepository
    {
        public CourseRepository(DbContext context)
            : base(context)
        {
        }
    }
}
