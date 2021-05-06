using FluentValidation;
using Hdn.Core.Architecture.Api.Extensions;
using Hdn.Core.Architecture.Api.Middlewares;
using Hdn.Core.Architecture.Api.Services;
using Hdn.Core.Architecture.Application;
using Hdn.Core.Architecture.Application.Dtos.Product;
using Hdn.Core.Architecture.Application.Dtos.Tenant;
using Hdn.Core.Architecture.Application.Interfaces;
using Hdn.Core.Architecture.Application.Interfaces.Providers;
using Hdn.Core.Architecture.Application.Providers;
using Hdn.Core.Architecture.Application.Validator;
using Hdn.Core.Architecture.Infrastructure;
using Hdn.Core.Architecture.Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Hdn.Core.Architecture
{
    public class Startup
    {
        public IConfiguration _config { get; }
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationLayer();
            services.AddIdentityInfrastructure(_config);
            services.AddPersistenceInfrastructure(_config);
            //services.AddSharedInfrastructure(_config);
            services.AddSwaggerExtension();
            services.AddControllers();
            services.AddApiVersioningExtension();
            services.AddHealthChecks();

            #region Services

            services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();

            #endregion

            #region Providers

            services.AddSingleton<IMessageProvider, MessageProvider>();

            #endregion

            #region Validators

            services.AddScoped<IValidator<ProductRequest>, ProductRequestValidator>();
            services.AddScoped<IValidator<TenantRequest>, TenantRequestValidator>();

            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwaggerExtension();       
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseHealthChecks("/health");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
