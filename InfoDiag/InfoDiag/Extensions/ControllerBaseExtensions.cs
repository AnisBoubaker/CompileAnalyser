namespace InfoDiag.Extensions
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using Constants.Enums;
    using Entity.DTO;
    using Microsoft.AspNetCore.Mvc;

    public static class ControllerBaseExtensions
    {
        public static UserDto UserDto(this ControllerBase cb)
        {
            return new UserDto
            {
                Email = cb.User.Claims.Where(c => c.Type == ClaimTypes.Email).Single().Value,
                Role = (UserRole)Enum.Parse(typeof(UserRole), cb.User.Claims.Where(c => c.Type == "Role").Single().Value),
            };
        }
    }
}
