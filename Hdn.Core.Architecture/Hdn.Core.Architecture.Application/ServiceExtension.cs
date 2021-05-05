using System.Reflection;
using Hdn.Core.Architecture.Application.Interfaces.Services;
using Hdn.Core.Architecture.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Hdn.Core.Architecture.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            #region Services
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ITenantService, TenantService>();
            #endregion

        }
    }
}
