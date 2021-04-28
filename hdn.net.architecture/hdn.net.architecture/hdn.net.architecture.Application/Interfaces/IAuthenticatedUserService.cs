using System;
using System.Collections.Generic;
using System.Text;

namespace hdn.net.architecture.Application.Interfaces
{
    public interface IAuthenticatedUserService
    {
        string UserId { get; }
    }
}
