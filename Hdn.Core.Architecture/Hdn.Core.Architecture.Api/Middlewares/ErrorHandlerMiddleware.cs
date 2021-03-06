using FluentValidation;
using Hdn.Core.Architecture.Application.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hdn.Core.Architecture.Api.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ErrorHandlerMiddleware(
            RequestDelegate next,
            ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string>() { Succeeded = false, Message = error?.Message };

                switch (error)
                {
                    case Application.Exceptions.ApiException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        _logger.LogError(error.ToString());
                        break;

                    case ValidationException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        foreach(var erro in e.Errors)
                        {
                            responseModel.Errors.Add(erro.ToString());
                            _logger.LogWarning(string.Join(string.Empty, erro));
                        }                           
                        break;

                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        _logger.LogError(error.ToString());
                        break;

                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        _logger.LogError(error.ToString());
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}
