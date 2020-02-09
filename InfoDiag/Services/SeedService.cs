using System;
using System.Collections.Generic;
using System.Linq;
using Constants.Enums;
using Constants.Extentions;
using Entity;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class SeedService : ISeedService
    {
        private const string _seedPassword = "9TwlonUcSEeLv08D7nSzjU0XL1dNi/NXjBdYutbI8SMMiJG2hf10/Q68YUAxVq+a"; // 1234

        private readonly IUserRepository _userRepository;
        private readonly IInstitutionRepository _institutionRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly ITermRepository _termRepository;
        private readonly ITermService _termService;
        private readonly ICourseGroupRepository _courseGroupRepository;
        private readonly ICodingLanguageRepository _codingLanguageRepository;

        public SeedService(
            IUserRepository userRepository,
            IInstitutionRepository institutionRepository,
            ICourseRepository courseRepository,
            ITermRepository termRepository,
            ITermService termService,
            ICourseGroupRepository courseGroupRepository,
            ICodingLanguageRepository codingLanguageRepository)
        {
            _userRepository = userRepository;
            _institutionRepository = institutionRepository;
            _courseRepository = courseRepository;
            _termRepository = termRepository;
            _termService = termService;
            _courseGroupRepository = courseGroupRepository;
            _codingLanguageRepository = codingLanguageRepository;
        }

        public void Seed()
        {
            User admin = null;
            User coordo = null;
            User teacher = null;

            if (!_userRepository.AllAsQueryable.Any())
            {
                admin = SeedAdminUser();
                coordo = SeedCoordo();
                teacher = SeedTeacher();
            }
            else
            {
                var userByRoles = _userRepository.AllAsQueryable.ToList().GroupBy(u => u.Role).Select(g => new { Role = g.Key, Element = g.First() });
                admin = userByRoles.First(ubr => ubr.Role == UserRole.Admin).Element;
                coordo = userByRoles.First(ubr => ubr.Role == UserRole.Coordinator).Element;
                teacher = userByRoles.First(ubr => ubr.Role == UserRole.Teacher).Element;
            }

            var institution = _institutionRepository.AllAsQueryable.FirstOrDefault();

            if (institution == null)
            {
                institution = SeedInstitution();
            }

            var langs = SeedLanguages();

            if (!_courseRepository.AllAsQueryable.Any())
            {
                int id = langs.First(l => l.Code == CodingLanguageEnum.CPP).Id;
                institution.Courses = new List<Course>
                {
                    _courseRepository.Insert(new Course
                    {
                        Id = "INF147",
                        CodingLanguageId = id,
                    }),
                    _courseRepository.Insert(new Course
                    {
                        Id = "INF155",
                        CodingLanguageId = id,
                    }),
                };
                _institutionRepository.Update(institution);
            }

            var term = _termRepository.AllAsQueryable.FirstOrDefault();

            if (term == null)
            {
                _termService.CreateCurrentTerm();
                term = _termRepository.AllAsQueryable.FirstOrDefault();

            }

            // Generate a course group of each
            if (!_courseGroupRepository.AllAsQueryable.Any())
            {
                var course = institution.Courses.ElementAt(0);
                var group = new CourseGroup
                {
                    GroupNumber = 98,
                    CourseId = course.Id,
                    TermId = term.Id,
                };

                _courseGroupRepository.Insert(group);

                Assign(group, admin, coordo, teacher);

                course = institution.Courses.ElementAt(1);
                group = new CourseGroup
                {
                    GroupNumber = 99,
                    CourseId = course.Id,
                    TermId = term.Id,
                };

                _courseGroupRepository.Insert(group);

                Assign(group, admin);
            }

            if (!_courseGroupRepository.AllAsQueryable.Any(c => c.Id == "INF155-A18-2"))
            {
                CreateTestCourseGroup(institution.Courses.Last());
            }
        }

        private void CreateTestCourseGroup(Course course)
        {
            var term = _termRepository.Insert(new Term
            {
                Id = "A18",
                TermType = Constants.TermTypeEnum.Fall,
                Year = 2018,
            });

            _courseGroupRepository.Insert(new CourseGroup
            {
                // TODO this is for testing with : micha_INF155_Projet2_20181030150250
                GroupNumber = 2,
                CourseId = course.Id,
                TermId = term.Id,
            });
        }

        private IEnumerable<CodingLanguage> SeedLanguages()
        {
            if (!_codingLanguageRepository.AllAsQueryable.Any())
            {
                var dic = EnumExtensions.ToTupple(typeof(CodingLanguageEnum));

                var toInsert = dic.Select(t => new CodingLanguage
                {
                    Code = (CodingLanguageEnum)t.key,
                    Name = t.value,
                });
                _codingLanguageRepository.Insert(toInsert);
            }

            return _codingLanguageRepository.All;
        }

        // this could and maybe should be made the other way around
        private void Assign(CourseGroup group, params User[] users)
        {
            foreach (var user in users)
            {
                if (user.CourseGroupUsers == null)
                {
                    user.CourseGroupUsers = new List<CourseGroupUser>();
                }

                user.CourseGroupUsers.Add(new CourseGroupUser
                {
                    CourseGroupId = group.Id,
                    UserId = user.Id,
                });

                _userRepository.Update(user);
            }
        }

        private Institution SeedInstitution()
        {
            return _institutionRepository.Insert(new Institution
            {
                Alias = "ETS",
                Name = "École de technologie Supérieure",
            });
        }

        private User SeedCoordo()
        {
            return _userRepository.Insert(new User
            {
                Email = "test@coordo.com",
                FirstName = "test",
                LastName = "coordo",
                Role = UserRole.Coordinator,
                Password = _seedPassword,
            });
        }

        private User SeedTeacher()
        {
            return _userRepository.Insert(new User
            {
                Email = "test@teacher.com",
                FirstName = "test",
                LastName = "teacher",
                Role = UserRole.Teacher,
                Password = _seedPassword,
            });
        }

        private User SeedAdminUser()
        {
            return _userRepository.Insert(new User
            {
                Email = "admin@admin.com",
                FirstName = "admin",
                LastName = "admin",
                Role = UserRole.Admin,
                Password = _seedPassword,
            });
        }
    }
}
