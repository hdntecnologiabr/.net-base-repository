﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Hdn.Core.Architecture.Application.Dtos.Account
{
    public class AuthenticationRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}