using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.Uf;
using Api.Domain.Intereface.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Municipio.QuandoRequisitadoGetCompleteByIBGE
{
    public class BadRequest
    {
        private MunicipioController _controller;

        [Fact(DisplayName = "BadRequest Metodo Get Complete de municipio")]
        public async Task RetornoBadRequest_MetodoGetCompleteByIBGE()
        {
            var _serviceMock = new Mock<IMunicipioservice>();
            _serviceMock.Setup(m => m.GetCompleteByIBGE(It.IsAny<int>()))
                        .ReturnsAsync(new MunicipioDtoCompleto()
                        {
                            Id = Guid.NewGuid(),
                            Nome = Faker.Address.City(),
                            CodIBGE = Faker.RandomNumber.Next(10000, 999999),
                            UfID = Guid.NewGuid(),
                            Uf = new UfDto
                            {
                                Id = Guid.NewGuid(),
                                Nome = Faker.Country.Name(),
                                Sigla = Faker.Country.Name().Substring(1, 3)
                            }
                        });

            _controller = new MunicipioController(_serviceMock.Object);
            _controller.ModelState.AddModelError("Ibge", "Formato Inválido");

            var result = await _controller.GetCompleteByIBGE(Faker.RandomNumber.Next(10000, 99999));
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
