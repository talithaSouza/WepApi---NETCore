using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.Uf;
using Api.Domain.Intereface.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Municipio.QuandoRequisitadoGetComplete
{
    public class BadRequest
    {
        private MunicipioController _controller;

        [Fact(DisplayName = "BadRequest Metodo Get Complete de municipio")]
        public async Task RetornoBadRequest_MetodoGetComplete()
        {
            var _serviceMock = new Mock<IMunicipioservice>();
            _serviceMock.Setup(m => m.GetCompleteById(It.IsAny<Guid>()))
                        .ReturnsAsync(new MunicipioDtoCompleto()
                        {
                            Id = Guid.NewGuid(),
                            Nome = Faker.Address.City(),
                            CodIBGE = Faker.RandomNumber.Next(100000, 999999),
                            UfID = Guid.NewGuid(),
                            Uf = new UfDto
                            {
                                Id = Guid.NewGuid(),
                                Nome = Faker.Country.Name(),
                                Sigla = Faker.Country.Name().Substring(1, 3)
                            }
                        });

            _controller = new MunicipioController(_serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var result = await _controller.GetCompleteById(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
