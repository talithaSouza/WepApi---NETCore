using System;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Intereface.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarDelete
{
    public class RetornoBadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "Retorno de BadRequest no Delete")]
        public async void Eh_Possivel_Invocar_A_Controller_Delete()
        {
            var serviceMock = new Mock<IUserService>();

            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>()))
                        .ReturnsAsync(false);
            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("ID", "Formato Invalido");

            var result = await _controller.Delete(default(Guid));
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);

        }
    }
}
