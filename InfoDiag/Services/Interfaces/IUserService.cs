using System.Collections.Generic;
using Entity.DTO;

namespace Services.Interfaces
{
    public interface IUserService
    {
        UserDto AuthenticateUser(LoginDto dto);

        bool Exists(int userId);
    }
}
