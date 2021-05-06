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
            using (var reader = new StreamReader(context.Request.Body))
            {
                var body = await reader.ReadToEndAsync();
                if(body != "")
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    
                    var requestBase = JsonSerializer.Deserialize<RequestBase>(body, options);
                    context.Response.Headers.Add("tenantId", requestBase?.TenantId.ToString());
                }
            }           

            await _next(context);
        }
    }
}
