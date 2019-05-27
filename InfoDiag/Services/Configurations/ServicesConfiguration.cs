using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Configurations;
using Services.Interfaces;

namespace Services.Configurations
{
    public class ServicesConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            RepositoriesConfiguration.ConfigureServices(services, configuration);

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ICompilationService, CompilationService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ILogAnalyzerService, LogAnalyzerService>();
            services.AddScoped<IErrorCodeService, ErrorCodeService>();
        }
    }
}