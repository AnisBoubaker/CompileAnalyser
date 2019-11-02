namespace Services.Interfaces
{
    using System.Collections.Generic;
    using Entity.DTO;

    public interface IUserService
    {
        UserDto AuthenticateUser(LoginDto dto);

        IEnumerable<int> RelatedUserIds(int id);

        IEnumerable<int> RelatedUserIds(string email);
    }
}
