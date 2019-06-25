using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class CourseService : BaseService, ICourseService
    {
        private readonly Regex aliasRegex = new Regex("^{\\w}-{\\w}-{\\d}$");

        private readonly ICourseRepository courseRepository;
        private readonly ICourseGroupRepository courseGroupRepository;
        private readonly ITermRepository termRepository;

        public CourseService(
            ICourseRepository courseRepository,
            ICourseGroupRepository courseGroupRepository,
            ITermRepository termRepository)
        {
            this.courseRepository = courseRepository;
            this.courseGroupRepository = courseGroupRepository;
            this.termRepository = termRepository;
        }

        public bool ProcessCourseGroupAlias(string alias, int clientId)
        {
            (string courseAlias, string termAlias, int coursegroup) = SplitAlias(alias);

            var course = courseRepository.AllAsQueryable.Where(c => c.Id == courseAlias).Include(c => c.CourseGroups).FirstOrDefault();

            if (course == null)
            {
                return false;
            }

            var courseGroup = courseGroupRepository.AllAsQueryable.Where(cg => cg.CourseId == course.Id && cg.Alias == alias).FirstOrDefault();

            if (courseGroup == null)
            {
                return false;
            }

            if (courseGroup.Term.Alias != termAlias)
            {
                return false;
            }

            return true;
        }

        public (string courseAlias, string term, int coursegroup) SplitAlias(string alias)
        {
            var matches = aliasRegex.Match(alias);

            if (!matches.Success)
            {
                return (null, null, 0);
            }

            return (matches.Groups[1].Value, matches.Groups[2].Value, int.Parse(matches.Groups[3].Value));
        }
    }
}
