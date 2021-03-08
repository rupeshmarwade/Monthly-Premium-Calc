using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TAL.Infrastructure.Data;

namespace TAL.WebApi
{
    public class Program
    {
        public  static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();
            var db = scope.ServiceProvider.GetService<InsuranceDbContext>();
            db.Database.EnsureCreated();
            InsuranceDbContextSeed.Seed(db, scope.ServiceProvider.GetService<ILoggerFactory>());
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
