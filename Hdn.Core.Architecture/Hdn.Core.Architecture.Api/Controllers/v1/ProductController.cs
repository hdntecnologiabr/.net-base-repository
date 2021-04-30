using Hdn.Core.Architecture.Application.Dtos.Product;
using Hdn.Core.Architecture.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hdn.Core.Architecture.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProductController : BaseApiController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
            //intanciar service aqui 
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(ProductRequest product)
        {
            return Ok(await _productService.Create(product));
        }
    }

}
