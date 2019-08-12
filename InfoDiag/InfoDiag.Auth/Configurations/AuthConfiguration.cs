using InfoDiag.Auth.Managers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InfoDiag.Auth.Configurations
{
    public class AuthConfiguration
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IAuthService, JWTService>();
        }
    }
}
