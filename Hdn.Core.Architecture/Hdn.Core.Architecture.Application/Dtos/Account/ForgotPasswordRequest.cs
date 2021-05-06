using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hdn.Core.Architecture.Application.Dtos.Account
{
    public class ForgotPasswordRequest : RequestBase
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
