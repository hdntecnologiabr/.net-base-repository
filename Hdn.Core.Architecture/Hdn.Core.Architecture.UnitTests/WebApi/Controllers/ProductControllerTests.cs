using AutoFixture;
using Hdn.Core.Architecture.Api.Controllers.v1;
using Hdn.Core.Architecture.Application.Dtos.Product;
using Hdn.Core.Architecture.Application.Interfaces.Services;
using Hdn.Core.Architecture.Application.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Hdn.Core.Architecture.UnitTests.WebApi.Controllers
{
    public class ProductControllerTests
    {
        private Fixture _fixture;
        private Mock<IProductService> _productService;
        private ProductRequest _productRequest;
        private ProductController _controller;

        public ProductControllerTests()
        {
            _fixture = new Fixture();
            _productService = new Mock<IProductService>();
            _productRequest = _fixture.Create<ProductRequest>();
            _controller = new ProductController(_productService.Object);
        }

        [Fact]
        public void ProductController_Post_Deve_Disparar_Exception_Quando_Houver_Excecao()
        {
            #region Setup

            _productService.Setup(m => m.Create(_productRequest)).ThrowsAsync(_fixture.Create<Exception>());

            #endregion

            Assert.ThrowsAsync<Exception>(async () => await _controller.Post(_productRequest));
        }

        [Fact]
        public async Task ProductController_Post_Deve_Retornar_Ok_Quando_Operacao_For_Realizada_Com_Sucesso()
        {
            #region Setup

            _productService.Setup(m => m.Create(_productRequest)).ReturnsAsync(_fixture.Create<Response<int>>());

            #endregion

            var result = await _controller.Post(_productRequest);

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
