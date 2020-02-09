namespace Services.Interfaces
{
    using System.Collections.Generic;
    using Entity.DTO;

    public interface IUserService
    {
        UserDto AuthenticateUser(LoginDto dto);

        bool Exists(int userId);
    }
}
