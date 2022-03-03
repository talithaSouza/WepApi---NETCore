using System;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Intereface.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarCreate
{
    public class RetornoBadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "Retrona Bad Request da Created")]
        public async void Eh_Possivel_Invocar_A_Controller_Created()
        {
            var serviceMock = new Mock<IUserService>();
            string name = Faker.Name.FullName();
            string email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Post(It.IsAny<UserDtoCreate>()))
            .ReturnsAsync(new UserDtoCreateResult()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                CreateAt = DateTime.UtcNow
            });

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Name", "Nome não pode ser vazio");

            //Mocando o endereço URL da API para rotas
            Mock<IUrlHelper> urlMock = new Mock<IUrlHelper>();
            urlMock.Setup(m => m.Link(It.IsAny<String>(), It.IsAny<object>())).Returns(Faker.Internet.Url());
            _controller.Url = urlMock.Object;

            var userCreate = new UserDtoCreate()
            {
                Name = name,
                Email = email
            };

            var result = await _controller.Post(userCreate);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
