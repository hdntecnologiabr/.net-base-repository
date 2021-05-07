using Hdn.Core.Architecture.Api.Controllers;
using Hdn.Core.Architecture.Application.Dtos.Tenant;
using Hdn.Core.Architecture.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace hdn.net.architecture.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class TenantController : BaseApiController
    {
        private readonly ITenantService _tenantService;

        public TenantController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get(int pageNumber, int pageSize)
        {
            return Ok(await _tenantService.Get(pageNumber, pageSize));

        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _tenantService.GetById(id));
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] TenantRequest tenant)
        {
            return Ok(await _tenantService.Create(tenant));
        }

        // PUT api/<controller>/
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] TenantRequest tenant)
        {
            return Ok(await _tenantService.Update(tenant));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _tenantService.Delete(id));
        }
    }
}
