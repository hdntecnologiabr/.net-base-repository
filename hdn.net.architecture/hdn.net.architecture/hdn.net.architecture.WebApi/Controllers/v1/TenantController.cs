using hdn.net.architecture.Application.Features.Tenants.Commands.CreateTenant;
using hdn.net.architecture.Application.Features.Tenants.Commands.DeleteTenant;
using hdn.net.architecture.Application.Features.Tenants.Commands.UpdateTenant;
using hdn.net.architecture.Application.Features.Tenants.Queries.GetAllTenants;
using hdn.net.architecture.Application.Features.Tenants.Queries.GetTenantById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace hdn.net.architecture.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class TenantController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllTenantsParameter filter)
        {

            return Ok(await Mediator.Send(new GetAllTenantsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetTenantByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateTenantCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateTenantCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteTenantByIdCommand { Id = id }));
        }
    }
}
