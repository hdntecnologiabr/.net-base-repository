using FluentValidation;
using Hdn.Core.Architecture.Application.Dtos.Product;
using Hdn.Core.Architecture.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Hdn.Core.Architecture.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProductController : BaseApiController
    {
        private readonly IProductService _productService;
        private readonly IValidator<ProductRequest> _validator;

        public ProductController(
            IProductService productService,
            IValidator<ProductRequest> validator)
        {
            _productService = productService;
            _validator = validator;
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(ProductRequest product)
        {
            var validationResult = _validator.Validate(product);

            if (!validationResult.IsValid)
            {
                //_logger.LogWarning(string.Join(string.Empty, validationResult.Errors));
                throw new ValidationException(validationResult.Errors);
               // return new BadRequestObjectResult(validationResult.Errors);
            }

            return Ok(await _productService.Create(product));
            throw new Exception("Internal Server Error");

            //try
            //{
            //    return Ok(await _productService.Create(product));
            //}
            //catch (Exception e)
            //{
            //    _logger.LogError(e, $"[{ControllerContext.RouteData.Values["controller"]} - {ControllerContext.RouteData.Values["action"]}] - {e.Message}");
            //    return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            //}
        }
    }
}
