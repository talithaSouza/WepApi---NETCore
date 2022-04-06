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
    public class RetornoOK
    {
        private MunicipioController _controller;

        [Fact(DisplayName = "Retorno OK Metodo Get Complete de municipio")]
        public async Task RetornoOK_MetodoGetMunicipio()
        {
            Guid Id = Guid.NewGuid();
            var _serviceMock = new Mock<IMunicipioservice>();
            _serviceMock.Setup(m => m.GetCompleteById(Id))
                        .ReturnsAsync(new MunicipioDtoCompleto()
                        {
                            Id = Id,
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

            var result = await _controller.GetCompleteById(Id);
            Assert.True(result is OkObjectResult);
        }

    }
}
