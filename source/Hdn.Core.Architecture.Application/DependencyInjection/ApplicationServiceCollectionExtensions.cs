using Hdn.Core.Architecture.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Hdn.Core.Architecture.Application.DependencyInjection
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IMovieService, MovieService>();
        }
    }
}
