namespace Entity.DTO
{
    using System.Security.Claims;
    using Constants.Enums;

    public class UserDto
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public UserRole Role { get; set; }

        public string Name => FirstName + ' ' + LastName;
    }
}
