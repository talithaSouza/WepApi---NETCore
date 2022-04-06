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
    public class RetornoOkGet
    {
        private MunicipioController _controller;

        [Fact(DisplayName = "Retorno OK Metodo Get de municipio")]
        public async Task RetornoOK_MetodoGetMunicipio()
        {
            Guid Id = Guid.NewGuid();
            var _serviceMock = new Mock<IMunicipioservice>();
            _serviceMock.Setup(m => m.Get(Id))
                        .ReturnsAsync(new MunicipioDto()
                        {
                            Id = Id,
                            Nome = Faker.Address.City(),
                            CodIBGE = Faker.RandomNumber.Next(100000, 999999),
                            UfID = Guid.NewGuid()
                        });

            _controller = new MunicipioController(_serviceMock.Object);

            var result = await _controller.Get(Id);
            Assert.True(result is OkObjectResult);
        }
    }
}
