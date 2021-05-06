using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Hdn.Core.Architecture
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            //Read Configuration from appSettings
            //var config = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            //var host = CreateHostBuilder(args).Build();
            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            //    try
            //    {
            //        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            //        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            //        await Infrastructure.Identity.Seeds.DefaultRoles.SeedAsync(userManager, roleManager);
            //        await Infrastructure.Identity.Seeds.DefaultSuperAdmin.SeedAsync(userManager, roleManager);
            //        await Infrastructure.Identity.Seeds.DefaultBasicUser.SeedAsync(userManager, roleManager);

            //    }
            //    catch (Exception ex)
            //    {
            //        throw (ex);
            //    }

            //}
            //host.Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
