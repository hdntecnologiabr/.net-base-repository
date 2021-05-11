using System.ComponentModel.DataAnnotations;

namespace Hdn.Core.Architecture.Application.Dtos.Account
{
    public class ForgotPasswordRequest : RequestBase
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
