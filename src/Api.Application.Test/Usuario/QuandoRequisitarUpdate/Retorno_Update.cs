using System;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Intereface.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarUpdate
{
    public class Retorno_Update
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possivel realizar UPDATE")]
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

            Mock<IUrlHelper> urlMock = new Mock<IUrlHelper>();
            urlMock.Setup(m => m.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(Faker.Internet.Url());
            _controller.Url = urlMock.Object;

            var result = await _controller.Put(userDtoUpdate);
            Assert.True(result is OkObjectResult);

            UserDtoUpdateResult resultValue = ((OkObjectResult)result).Value as UserDtoUpdateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(userDtoUpdate.Name, resultValue.Name);



        }
    }
}
