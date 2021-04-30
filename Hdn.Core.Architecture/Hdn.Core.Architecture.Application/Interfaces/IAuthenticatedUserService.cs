using System;
using System.Collections.Generic;
using System.Text;

namespace Hdn.Core.Architecture.Application.Interfaces
{
    public interface IAuthenticatedUserService
    {
        string UserId { get; }
    }
}
