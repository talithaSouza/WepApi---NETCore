using System;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Intereface.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarUPDATE
{
    public class RetornoBadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "Retorno de BadRequest no UPDATE")]
        public async void Eh_Possivel_Invocar_A_Controller_Update()
        {
            var serviceMock = new Mock<IUserService>();
            string Nome = Faker.Name.FullName();
            string Email = Faker.Internet.Email();

            var userDtoUpdate = new UserDtoUpdate()
            {
                Id = Guid.NewGuid(),
                Name = Nome,
                Email = Email
            };

            serviceMock.Setup(m => m.Put(It.IsAny<UserDtoUpdate>()))
            .ReturnsAsync(new UserDtoUpdateResult()
            {
                Id = Guid.NewGuid(),
                Name = Nome,
                Email = Email,
                UpdateAt = DateTime.UtcNow
            });
            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Email", "É um campo obrigatório");

            var result = await _controller.Put(userDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);

        }
    }
}
