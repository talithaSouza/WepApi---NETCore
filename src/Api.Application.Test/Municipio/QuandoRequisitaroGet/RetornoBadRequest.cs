using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Intereface.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Municipio.QuandoRequisitaroGet
{
    public class RetornoBadRequest
    {
        private MunicipioController _controller;

        [Fact(DisplayName = "BadRequest Metodo Get de municipio")]
        public async Task RetornoBadRequest_MetodoGet()
        {
            var _serviceMock = new Mock<IMunicipioservice>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>()))
                        .ReturnsAsync(new MunicipioDto()
                        {
                            Id = Guid.NewGuid(),
                            Nome = Faker.Address.City(),
                            CodIBGE = Faker.RandomNumber.Next(100000, 999999),
                            UfID = Guid.NewGuid()
                        });

            _controller = new MunicipioController(_serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
