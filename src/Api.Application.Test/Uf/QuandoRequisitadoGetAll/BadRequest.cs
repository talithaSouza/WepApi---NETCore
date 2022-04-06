using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Uf;
using Api.Domain.Intereface.Services.Uf;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Uf.QuandoRequisitadoGetAll
{
    public class BadRequest
    {
        private UfController _controller;

        [Fact(DisplayName = "Retorno BadRequest Metodo GetALL Uf")]
        public async Task RetornoBadRequest_Uf_MetodoGET()
        {
            Mock<IUfService> _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.GetAll())
                        .ReturnsAsync(new List<UfDto>
                        {
                            new UfDto
                            {
                                Id = Guid.NewGuid(),
                                Nome = Faker.Address.UsState(),
                                Sigla = Faker.Address.UsState().Substring(1, 3),
                            },
                            new UfDto
                            {
                                Id = Guid.NewGuid(),
                                Nome = Faker.Address.UsState(),
                                Sigla = Faker.Address.UsState().Substring(1, 3),
                            },
                            new UfDto
                            {
                                Id = Guid.NewGuid(),
                                Nome = Faker.Address.UsState(),
                                Sigla = Faker.Address.UsState().Substring(1, 3),
                            }
                        });

            _controller = new UfController(_serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato inválido");

            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
