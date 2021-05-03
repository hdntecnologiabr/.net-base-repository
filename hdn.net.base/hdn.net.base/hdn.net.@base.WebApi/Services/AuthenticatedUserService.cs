using hdn.net._base.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace hdn.net._base.WebApi.Services
{
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue("uid");
        }

        public string UserId { get; }
    }
}
