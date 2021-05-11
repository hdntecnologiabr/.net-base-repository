using AutoFixture;
using Hdn.Core.Architecture.Api.Controllers;
using Hdn.Core.Architecture.Application.Dtos.Account;
using Hdn.Core.Architecture.Application.Interfaces.Services;
using Microsoft.Extensions.Primitives;
using Moq;
using System;
using Xunit;


namespace Hdn.Core.Architecture.UnitTests.WebApi.Controllers
{
    public class AccountControllerTests
    {
        private Fixture _fixture;
        private Mock<IAccountService> _accountService;
        private AccountController _controller;

        public AccountControllerTests()
        {
            _fixture = new Fixture();
            _accountService = new Mock<IAccountService>();
            _controller = new AccountController(_accountService.Object);
        }

        [Fact]
        public void AccountController_AuthenticateAsync_Deve_Disparar_Exception_Quando_Houver_Excecao()
        {
            #region Setup

            var request = _fixture.Create<AuthenticationRequest>();
            var ipAddress = _fixture.Create<string>();
            _accountService.Setup(m => m.AuthenticateAsync(request, ipAddress)).ThrowsAsync(_fixture.Create<Exception>());

            #endregion

            Assert.ThrowsAsync<Exception>(async () => await _controller.AuthenticateAsync(request));
        }

        [Fact]
        public void AccountController_RegisterAsync_Deve_Disparar_Exception_Quando_Houver_Excecao()
        {
            #region Setup

            var request = _fixture.Create<RegisterRequest>();
            var origin = _fixture.Create<StringValues>();
            _accountService.Setup(m => m.RegisterAsync(request, origin)).ThrowsAsync(_fixture.Create<Exception>());

            #endregion

            Assert.ThrowsAsync<Exception>(async () => await _controller.RegisterAsync(request));
        }
                
        [Fact]
        public void AccountController_ConfirmEmailAsync_Deve_Disparar_Exception_Quando_Houver_Excecao()
        {
            #region Setup

            var userId = _fixture.Create<string>();
            var code = _fixture.Create<string>();
            var origin = _fixture.Create<StringValues>();
            _accountService.Setup(m => m.ConfirmEmailAsync(userId, code)).ThrowsAsync(_fixture.Create<Exception>());

            #endregion

            Assert.ThrowsAsync<Exception>(async () => await _controller.ConfirmEmailAsync(userId, code));
        }


        [Fact]
        public void AccountController_ForgotPassword_Deve_Disparar_Exception_Quando_Houver_Excecao()
        {
            #region Setup

            var request = _fixture.Create<ForgotPasswordRequest>();
            var origin = _fixture.Create<StringValues>();
            _accountService.Setup(m => m.ForgotPassword(request, origin)).ThrowsAsync(_fixture.Create<Exception>());

            #endregion

            Assert.ThrowsAsync<Exception>(async () => await _controller.ForgotPassword(request));
        }


        [Fact]
        public void AccountController_ResetPassword_Deve_Disparar_Exception_Quando_Houver_Excecao()
        {
            #region Setup

            var request = _fixture.Create<ResetPasswordRequest>();
            _accountService.Setup(m => m.ResetPassword(request)).ThrowsAsync(_fixture.Create<Exception>());

            #endregion

            Assert.ThrowsAsync<Exception>(async () => await _controller.ResetPassword(request));
        }
    }
}
