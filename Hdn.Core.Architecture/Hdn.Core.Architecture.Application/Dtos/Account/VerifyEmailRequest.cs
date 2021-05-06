﻿using System.ComponentModel.DataAnnotations;

namespace Hdn.Core.Architecture.Application.Dtos.Account
{
    public class ResetPasswordRequest : RequestBase
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Token { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
