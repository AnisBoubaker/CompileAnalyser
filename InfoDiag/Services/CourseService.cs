namespace Services
{
    using System.Linq;
    using System.Text.RegularExpressions;
    using Microsoft.EntityFrameworkCore;
    using Repositories.Interfaces;
    using Services.Interfaces;
    using Services.Models;

    public class CourseService : BaseService, ICourseService
    {
        private readonly Regex _aliasRegex = new Regex("^(\\w*)-(\\w*)-(\\d*)$");

        private readonly ICourseRepository _courseRepository;
        private readonly ICourseGroupRepository _courseGroupRepository;
        private readonly ICourseGroupService _courseGroupService;

        public CourseService(
            ICourseRepository courseRepository,
            ICourseGroupRepository courseGroupRepository,
            ICourseGroupService courseGroupService)
        {
            _courseRepository = courseRepository;
            _courseGroupRepository = courseGroupRepository;
            _courseGroupService = courseGroupService;
        }

        public ServiceCallResult ProcessCourseGroupAlias(string alias, int clientId)
        {
            (string courseAlias, string termAlias, int coursegroup) = SplitAlias(alias);

            var course = _courseRepository.AllAsQueryable.Where(c => c.Id == courseAlias).Include(c => c.CourseGroups).FirstOrDefault();

            if (course == null)
            {
                return Error("Course cannot be found");
            }

            var courseGroup = _courseGroupRepository.AllAsQueryable.Include(cg => cg.CourseGroupClients).Where(cg => cg.CourseId == course.Id && cg.Id == courseAlias + "-" + termAlias + "-" + coursegroup).FirstOrDefault();

            if (courseGroup == null)
            {
                return Error("Course group cannot be found");
            }

            if (!courseGroup.CourseGroupClients.Any(cgc => cgc.ClientId == clientId))
            {
                _courseGroupService.AddStudent(clientId, courseGroup.Id);
            }

            return Success();
        }

        public (string courseAlias, string term, int coursegroup) SplitAlias(string alias)
        {
            var matches = _aliasRegex.Match(alias);

            if (!matches.Success)
            {
                return (null, null, 0);
            }

            var termString = matches.Groups[2].Value;
            if (termString.Length == 5)
            {
                termString = termString.Replace("20", string.Empty);
            }

            return (matches.Groups[1].Value, termString, int.Parse(matches.Groups[3].Value));
        }
    }
}
