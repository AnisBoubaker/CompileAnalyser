namespace Repositories.Configurations
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Repositories.Interfaces;

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
            // Adding repo should look like this : services.AddScoped<IBillRepository, BillRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ICompilationRepository, CompilationRepository>();
            services.AddScoped<IErrorCodeRepository, ErrorCodeRepository>();
            services.AddScoped<ICourseGroupRepository, CourseGroupRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IInstitutionRepository, InstitutionRepository>();
            services.AddScoped<ITermRepository, TermRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
