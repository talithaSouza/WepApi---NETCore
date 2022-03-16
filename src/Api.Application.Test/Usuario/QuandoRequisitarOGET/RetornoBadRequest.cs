using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Intereface.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarOGET
{
    public class RetornoBadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "Retorno Bad Request do GET")]
        public async Task BadRequest_GET()
        {
            var serviceMock = new Mock<IUserService>();
            string Nome = Faker.Name.FullName();
            string Email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>()))
                        .ReturnsAsync(new UserDto
                        {
                            Id = Guid.NewGuid(),
                            Name = Nome,
                            Email = Email,
                            CreateAt = DateTime.UtcNow
                        });

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("ID", "Formato inválido");

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);

        }
    }
}
