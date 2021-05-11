using Hdn.Core.Architecture.Application.Dtos.Account;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Hdn.Core.Architecture.Infrastructure.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TenantId { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
        public bool OwnsToken(string token)
        {
            return this.RefreshTokens?.Find(x => x.Token == token) != null;
        }
    }
}
