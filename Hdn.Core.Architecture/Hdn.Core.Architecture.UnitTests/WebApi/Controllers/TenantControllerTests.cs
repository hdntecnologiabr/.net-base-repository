using AutoFixture;
using hdn.net.architecture.WebApi.Controllers.v1;
using Hdn.Core.Architecture.Application.Dtos.Tenant;
using Hdn.Core.Architecture.Application.Interfaces.Services;
using Hdn.Core.Architecture.Application.Wrappers;
using Hdn.Core.Architecture.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Hdn.Core.Architecture.UnitTests.WebApi.Controllers
{
    public class TenantControllerTests
    {
        private Fixture _fixture;
        private Mock<ITenantService> _tenantService;
        private TenantRequest _tenantRequest;
        private TenantController _controller;

        public TenantControllerTests()
        {
            _fixture = new Fixture();
            _tenantService = new Mock<ITenantService>();
            _tenantRequest = _fixture.Create<TenantRequest>();
            _controller = new TenantController(_tenantService.Object);
        }

        [Fact]
        public void TenantController_Get_Deve_Disparar_Exception_Quando_Houver_Excecao()
        {
            #region Setup

            var pageNumber = _fixture.Create<int>();
            var pageSize = _fixture.Create<int>();

            _tenantService.Setup(m => m.Get(pageNumber, pageSize)).ThrowsAsync(_fixture.Create<Exception>());

            #endregion

            Assert.ThrowsAsync<Exception>(async () => await _controller.Get(pageNumber, pageSize));
        }

        [Fact]
        public async Task TenantController_Get_Deve_Retornar_Ok_Quando_Operacao_For_Realizada_Com_Sucesso()
        {
            #region Setup

            var pageNumber = _fixture.Create<int>();
            var pageSize = _fixture.Create<int>();

            _tenantService.Setup(m => m.Get(pageNumber, pageSize)).ReturnsAsync(_fixture.Create<Response<IReadOnlyList<Tenant>>>());

            #endregion

            var result = await _controller.Get(pageNumber, pageSize);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void TenantController_Get_ById_Deve_Disparar_Exception_Quando_Houver_Excecao()
        {
            #region Setup

            var id = _fixture.Create<int>();

            _tenantService.Setup(m => m.GetById(id)).ThrowsAsync(_fixture.Create<Exception>());

            #endregion

            Assert.ThrowsAsync<Exception>(async () => await _controller.Get(id));
        }

        [Fact]
        public async Task TenantController_Get__ById_Deve_Retornar_Ok_Quando_Operacao_For_Realizada_Com_Sucesso()
        {
            #region Setup

            var id = _fixture.Create<int>();

            _tenantService.Setup(m => m.GetById(id)).ReturnsAsync(_fixture.Create<Response<Tenant>>());

            #endregion

            var result = await _controller.Get(id);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void TenantController_Post_Deve_Disparar_Exception_Quando_Houver_Excecao()
        {
            #region Setup

            _tenantService.Setup(m => m.Create(_tenantRequest)).ThrowsAsync(_fixture.Create<Exception>());

            #endregion

            Assert.ThrowsAsync<Exception>(async () => await _controller.Post(_tenantRequest));
        }

        [Fact]
        public async Task TenantController_Post_Deve_Retornar_Ok_Quando_Operacao_For_Realizada_Com_Sucesso()
        {
            #region Setup

            _tenantService.Setup(m => m.Create(_tenantRequest)).ReturnsAsync(_fixture.Create<Response<int>>());

            #endregion

            var result = await _controller.Post(_tenantRequest);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void TenantController_Put_Deve_Disparar_Exception_Quando_Houver_Excecao()
        {
            #region Setup

            _tenantService.Setup(m => m.Update(_tenantRequest)).ThrowsAsync(_fixture.Create<Exception>());

            #endregion

            Assert.ThrowsAsync<Exception>(async () => await _controller.Put(_tenantRequest));
        }

        [Fact]
        public async Task TenantController_Put_Deve_Retornar_Ok_Quando_Operacao_For_Realizada_Com_Sucesso()
        {
            #region Setup

            _tenantService.Setup(m => m.Update(_tenantRequest)).ReturnsAsync(_fixture.Create<Response<int>>());

            #endregion

            var result = await _controller.Put(_tenantRequest);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void TenantController_Delete_Deve_Disparar_Exception_Quando_Houver_Excecao()
        {
            #region Setup

            var id = _fixture.Create<int>();

            _tenantService.Setup(m => m.Delete(id)).ThrowsAsync(_fixture.Create<Exception>());

            #endregion

            Assert.ThrowsAsync<Exception>(async () => await _controller.Delete(id));
        }

        [Fact]
        public async Task TenantController_Delete_Deve_Retornar_Ok_Quando_Operacao_For_Realizada_Com_Sucesso()
        {
            #region Setup

            var id = _fixture.Create<int>();

            _tenantService.Setup(m => m.Delete(id)).ReturnsAsync(_fixture.Create<Response<int>>());

            #endregion

            var result = await _controller.Delete(id);

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
