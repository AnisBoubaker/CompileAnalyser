namespace Entity
{
    using System.Collections.Generic;
    using System.Linq;
    using Constants.Enums;

    public class User : IBaseEntity<int>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public UserRole Role { get; set; }

        public string Password { get; set; }

        public virtual ICollection<CourseGroupUser> CourseGroupUsers { get; set; }

        public IEnumerable<CourseGroup> CourseGroups => CourseGroupUsers.Select(cgu => cgu.CourseGroup);
    }
}
