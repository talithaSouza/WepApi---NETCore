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
    public class RetornoGET
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possivel realizar GET")]
        public async Task Eh_Possivel_Invocar_A_Controller_GET()
        {
            var serviceMock = new Mock<IUserService>();
            string Nome = Faker.Name.FullName();
            string Email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>()))
            .ReturnsAsync(new UserDto()
            {
                Id = Guid.NewGuid(),
                Name = Nome,
                Email = Email,
                CreateAt = DateTime.UtcNow
            });
            _controller = new UsersController(serviceMock.Object);

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as UserDto;
            Assert.NotNull(resultValue);
            Assert.Equal(Nome, resultValue.Name);
            Assert.Equal(Email, resultValue.Email);

        }
    }
}
