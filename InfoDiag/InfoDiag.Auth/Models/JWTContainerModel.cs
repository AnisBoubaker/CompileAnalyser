using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace InfoDiag.Auth.Models
{
    public class JWTContainerModel : IAuthContainerModel
    {
        public string SecretKey { get; set; } = "CLETRESSECRETTE";

        public string SecurityAlgorithm { get; set; } = SecurityAlgorithms.HmacSha256;

        public int ExpireMinutes { get; set; } = 10080;

        public Claim[] Claims { get; set; }
    }
}
