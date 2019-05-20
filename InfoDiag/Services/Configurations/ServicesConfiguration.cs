using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Configurations;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Configurations
{
    public class ServicesConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            RepositoriesConfiguration.ConfigureServices(services, configuration);

            services.AddScoped<ICompilationService, CompilationService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ILogAnalyzerService, LogAnalyzerService>();
        }
    }
}