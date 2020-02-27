using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;

namespace Tasks.Configurations
{
    public class TasksConfiguration
    {
        public static void ConfigureService(IServiceCollection services, IConfiguration config)
        {
            HangfireConfiguration.ConfigureServices(services, config);
        }

        public static void AddTasksUi(IApplicationBuilder app)
        {
            HangfireConfiguration.AddTasksUi(app);
        }

        public static void StartTasks()
        {

            RecurringJob.AddOrUpdate("stats", (IStatService stat) => stat.ProcessNewCompilation(), "*/10 * * * *");
        }
    }
}
