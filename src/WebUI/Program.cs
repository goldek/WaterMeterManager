using Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using System;
using System.Threading.Tasks;
using WaterMeterManager.API;
using WaterMeterManager.Infrastructure.Persistence;

namespace WaterMeterManager.WebUI
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();

                    if (context.Database.IsSqlServer())
                    {
                        context.Database.Migrate();
                    }
                    await ApplicationDbContextSeed.SeedSampleDataAsync(context);
                }
                catch (Exception ex)
                {
                    var logger = LogManager.GetCurrentClassLogger();
                    logger.Error(ex, "An error occurred while migrating or seeding the database.");
                }
            }
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}