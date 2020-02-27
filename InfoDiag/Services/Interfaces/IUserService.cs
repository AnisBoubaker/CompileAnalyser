namespace Services.Interfaces
{
    using System.Collections.Generic;
    using Entity.DTO;
    using Services.Models;

    public interface IUserService
    {
        ServiceCallResult<UserDto> AuthenticateUser(LoginDto dto);

        ServiceCallResult<IEnumerable<UserDto>> GetAll();
    }
}
