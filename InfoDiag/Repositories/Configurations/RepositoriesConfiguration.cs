using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Interfaces;

namespace Repositories.Configurations
{
    public class RepositoriesConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<DbContext, InfoDiagContext>(opt =>
            {
                opt.UseSqlServer(configuration
                                     .GetConnectionString("DefaultConnection"));
            });

            // Add repos here
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ICompilationRepository, CompilationRepository>();
            services.AddScoped<IErrorCodeRepository, ErrorCodeRepository>();
            services.AddScoped<ICourseGroupRepository, CourseGroupRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IInstitutionRepository, InstitutionRepository>();
            services.AddScoped<ITermRepository, TermRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICodingLanguageRepository, CodingLanguageRepository>();
            services.AddScoped<IStatsRepository, StatsRepository>();
            services.AddScoped<IStatLineRepository, StatLineRepository>();
        }
    }
}
