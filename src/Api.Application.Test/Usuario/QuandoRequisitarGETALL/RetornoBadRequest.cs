using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Intereface.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarGETALL
{
    public class RetornoBadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "Retorno Bad Request do GETALL")]
        public async Task BadRequest_GETALL()
        {
            var serviceMock = new Mock<IUserService>();
            string Nome = Faker.Name.FullName();
            string Email = Faker.Internet.Email();

            serviceMock.Setup(m => m.GetAll())
                        .ReturnsAsync(new List<UserDto>
                            {
                                new UserDto
                                {
                                    Id = Guid.NewGuid(),
                                    Name = Faker.Name.FullName(),
                                    Email = Faker.Internet.Email(),
                                    CreateAt = DateTime.UtcNow
                                },
                                new UserDto
                                {
                                    Id = Guid.NewGuid(),
                                    Name = Faker.Name.FullName(),
                                    Email = Faker.Internet.Email(),
                                    CreateAt = DateTime.UtcNow
                                },
                                new UserDto
                                {
                                    Id = Guid.NewGuid(),
                                    Name = Faker.Name.FullName(),
                                    Email = Faker.Internet.Email(),
                                    CreateAt = DateTime.UtcNow
                                }
                            });

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Error", "Inválido");

            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);

        }
    }
}
