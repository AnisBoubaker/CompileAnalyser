using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Constants.Enums;
using Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace InfoDiag.Extensions
{
    public static class ControllerBaseExtensions
    {
        public static UserDto UserDto(this ControllerBase cb)
        {
            if (!cb.User.Claims.Any())
            {
                return null;
            }

            return new UserDto
            {
                Email = cb.User.Claims.Where(c => c.Type == ClaimTypes.Email).Single().Value,
                Role = (UserRole)Enum.Parse(typeof(UserRole), cb.User.Claims.Where(c => c.Type == "Role").Single().Value),
            };
        }
    }
}
