using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace InfoDiag.Auth.Models
{
    public interface IAuthContainerModel
    {
        string SecretKey { get; set; }

        string SecurityAlgorithm { get; set; }

        int ExpireMinutes { get; set; }

        Claim[] Claims { get; set; }
    }
}
