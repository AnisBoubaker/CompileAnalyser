using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Services.Interfaces;
using Services.Models;

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

        public ServiceCallResult ProcessCourseGroupAlias(string alias, int clientId)
        {
            (string courseAlias, string termAlias, int coursegroup) = SplitAlias(alias);

            var course = courseRepository.AllAsQueryable.Where(c => c.Id == courseAlias).Include(c => c.CourseGroups).FirstOrDefault();

            if (course == null)
            {
                return Error("Course cannot be found");
            }

            var courseGroup = courseGroupRepository.AllAsQueryable.Where(cg => cg.CourseId == course.Id && cg.Alias == alias).FirstOrDefault();

            if (courseGroup == null)
            {
                return Error("Course group cannot be found");
            }

            if (courseGroup.Term.Alias != termAlias)
            {
                return Error("Term cannot be found");
            }

            return Success();
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
