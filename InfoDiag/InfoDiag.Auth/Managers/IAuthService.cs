using InfoDiag.Auth.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace InfoDiag.Auth.Managers
{
    public interface IAuthService
    {
        string SecretKey { get; set; }

        bool IsTokenValid(string token);

        string GenerateToken(IAuthContainerModel model);

        IEnumerable<Claim> GetTokenClaims(string token);
    }
}
