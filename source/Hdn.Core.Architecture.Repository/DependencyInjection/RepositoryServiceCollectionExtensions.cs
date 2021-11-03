using Hdn.Core.Architecture.Domain.Interfaces.Repository;
using Hdn.Core.Architecture.Repository.Context;
using Hdn.Core.Architecture.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Hdn.Core.Architecture.Repository.DependencyInjection
{
    public static class RepositoryServiceCollectionExtensions
    {
        public static void AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetSection("UseInMemoryDatabase").Value == bool.TrueString)
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("TemplateDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseSqlServer(
                       configuration.GetConnectionString("DefaultConnection"),
                       b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }
            services.AddScoped<IMovieRepository, MovieRepository>();
        }
    }
}
