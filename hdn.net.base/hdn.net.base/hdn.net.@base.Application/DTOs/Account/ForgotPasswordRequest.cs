using System.ComponentModel.DataAnnotations;

namespace hdn.net._base.Application.DTOs.Account
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
