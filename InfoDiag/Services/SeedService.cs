namespace Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Constants.Enums;
    using Entity;
    using Repositories.Interfaces;
    using Services.Interfaces;

    public class SeedService : ISeedService
    {
        private const string _seedPassword = "9TwlonUcSEeLv08D7nSzjU0XL1dNi/NXjBdYutbI8SMMiJG2hf10/Q68YUAxVq+a"; // 1234

        private readonly IUserRepository _userRepository;
        private readonly IInstitutionRepository _institutionRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly ITermRepository _termRepository;
        private readonly ITermService _termService;

        public SeedService(
            IUserRepository userRepository,
            IInstitutionRepository institutionRepository,
            ICourseRepository courseRepository,
            ITermRepository termRepository,
            ITermService termService)
        {
            _userRepository = userRepository;
            _institutionRepository = institutionRepository;
            _courseRepository = courseRepository;
            _termRepository = termRepository;
            _termService = termService;
        }

        public void Seed()
        {
            if (!_userRepository.AllAsQueryable.Any())
            {
                SeedTeacher(SeedCoordo(SeedAdminUser()));
            }

            var institution = _institutionRepository.AllAsQueryable.FirstOrDefault();

            if (institution == null)
            {
                institution = SeedInstitution();
            }

            if (!_courseRepository.AllAsQueryable.Any())
            {
                institution.Courses = new List<Course>
                {
                    _courseRepository.Insert(new Course
                    {
                        Name = "INF147",
                    }),
                    _courseRepository.Insert(new Course
                    {
                        Name = "INF155",
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

            //
        }

        private Institution SeedInstitution()
        {
            return _institutionRepository.Insert(new Institution
            {
                Alias = "ETS",
                Name = "École de technologie Supérieure",
            });
        }

        private User SeedCoordo(User admin)
        {
            return _userRepository.Insert(new User
            {
                Email = "test@coordo.com",
                FirstName = "test",
                LastName = "coordo",
                Role = UserRole.Coordinator,
                Password = _seedPassword,
                ManagerId = admin.Id,
            });
        }

        private User SeedTeacher(User coodro)
        {
            return _userRepository.Insert(new User
            {
                Email = "test@teacher.com",
                FirstName = "test",
                LastName = "teacher",
                Role = UserRole.Teacher,
                Password = _seedPassword,
                ManagerId = coodro.Id,
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
