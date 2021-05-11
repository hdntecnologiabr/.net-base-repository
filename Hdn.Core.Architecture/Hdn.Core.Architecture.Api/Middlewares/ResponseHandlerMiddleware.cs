using Hdn.Core.Architecture.Application.Dtos;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hdn.Core.Architecture.Api.Middlewares
{
    public class ResponseHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Request.EnableBuffering();
            var body = await new StreamReader(context.Request.Body).ReadToEndAsync();

            if (body != "")
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var requestBase = JsonSerializer.Deserialize<RequestBase>(body, options);
                context.Response.Headers.Add("tenantId", requestBase?.TenantId.ToString());
            }

            context.Request.Body.Seek(0, SeekOrigin.Begin);            
            await _next(context);
        }
    }
}
