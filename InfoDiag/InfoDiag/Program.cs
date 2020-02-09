namespace InfoDiag
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    public class Program
    {
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                          .UseStartup<Startup>();
        }

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
    }
}
