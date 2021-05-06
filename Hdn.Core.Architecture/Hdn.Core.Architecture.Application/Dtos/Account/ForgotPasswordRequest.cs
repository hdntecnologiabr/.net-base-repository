using System.ComponentModel.DataAnnotations;

namespace Hdn.Core.Architecture.Application.Dtos.Account
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
