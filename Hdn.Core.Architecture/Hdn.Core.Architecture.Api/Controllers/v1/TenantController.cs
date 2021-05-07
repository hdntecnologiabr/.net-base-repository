using FluentValidation;
using Hdn.Core.Architecture.Api.Controllers;
using Hdn.Core.Architecture.Application.Dtos.Tenant;
using Hdn.Core.Architecture.Application.Interfaces.Providers;
using Hdn.Core.Architecture.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hdn.net.architecture.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class TenantController : BaseApiController
    {
        private readonly ITenantService _tenantService;
        private readonly IValidator<TenantRequest> _validator;
        private readonly IMessageProvider _messageProvider;

        public TenantController(
            ITenantService tenantService,
            IValidator<TenantRequest> validator,
            IMessageProvider messageProvider)
        {
            _tenantService = tenantService;
            _validator = validator;
            _messageProvider = messageProvider;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get(int pageNumber, int pageSize)
        {
            if (pageNumber == 0 || pageSize == 0)
            {
                var message = new List<string>();

                if (pageNumber == 0)
                    message.Add(_messageProvider.RequiredParameter(nameof(pageNumber)));

                if (pageSize == 0)
                    message.Add(_messageProvider.RequiredParameter(nameof(pageSize)));

                return new BadRequestObjectResult(message);
            }

            try
            {
                return Ok(await _tenantService.Get(pageNumber, pageSize));
            }
            catch (Exception e)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }


        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
            {
                var message = _messageProvider.RequiredParameter(nameof(id));

                return new BadRequestObjectResult(message);
            }

            try
            {
                var tenant = await _tenantService.GetById(id);

                if (tenant is null)
                    return new NotFoundObjectResult(_messageProvider.RegisterNotFound(nameof(id), id.ToString()));

                return Ok(tenant);
            }
            catch (Exception e)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] TenantRequest tenant)
        {
            var validationResult = _validator.Validate(tenant);

            if (!validationResult.IsValid)
            {
                return new BadRequestObjectResult(validationResult.Errors);
            }

            try
            {
                return Ok(await _tenantService.Create(tenant));
            }
            catch (Exception e)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<controller>/
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] TenantRequest tenant)
        {
            var validationResult = _validator.Validate(tenant);

            if (!validationResult.IsValid)
            {
                return new BadRequestObjectResult(validationResult.Errors);
            }

            try
            {
                return Ok(await _tenantService.Update(tenant));
            }
            catch (Exception e)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError); ;
            }

        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                var message = _messageProvider.RequiredParameter(nameof(id));

                return new BadRequestObjectResult(message);
            }

            try
            {
                return Ok(await _tenantService.Delete(id));
            }
            catch (Exception e)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
