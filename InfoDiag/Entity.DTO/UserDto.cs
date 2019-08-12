using System.Security.Claims;
using Constants.Enums;

namespace Entity.DTO
{
    public class UserDto
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public UserRole Role { get; set; }

        public string Name => FirstName + ' ' + LastName;
    }
}
