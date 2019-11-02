namespace Entity
{
    using System.Collections.Generic;
    using Constants.Enums;

    public class User : IBaseEntity<int>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public UserRole Role { get; set; }

        public string Password { get; set; }

        public virtual ICollection<User> Employees { get; set; }

        public virtual ICollection<CourseGroup> CourseGroups { get; set; }

        public virtual User Manager { get; set; }

        public int? ManagerId { get; set; }
    }
}
