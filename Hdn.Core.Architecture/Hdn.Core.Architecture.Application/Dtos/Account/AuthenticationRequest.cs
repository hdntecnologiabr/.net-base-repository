﻿namespace Hdn.Core.Architecture.Application.Dtos.Account
{
    public class AuthenticationRequest : RequestBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
