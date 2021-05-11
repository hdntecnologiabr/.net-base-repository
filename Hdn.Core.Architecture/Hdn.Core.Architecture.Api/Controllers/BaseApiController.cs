using Microsoft.AspNetCore.Mvc;

namespace Hdn.Core.Architecture.Api.Controllers
{

    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
    }
}
