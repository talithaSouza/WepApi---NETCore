using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Intereface.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarGETALL
{
    public class RetornoGETALL
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possivel requisitar o metodo GETALL")]
        public async Task Eh_Possivel_Chamar_GettALL()
        {
            var serviceMock = new Mock<IUserService>();
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
            var result = await _controller.GetAll();
            Assert.True(result is OkObjectResult);

            var listResult = ((OkObjectResult)result).Value as IEnumerable<UserDto>;
            Assert.True(listResult.Count() == 3);
        }
    }
}
