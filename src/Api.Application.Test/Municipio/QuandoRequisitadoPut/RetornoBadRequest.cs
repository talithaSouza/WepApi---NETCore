using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Intereface.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Municipio.QuandoRequisitadoPut
{
    public class RetornoBadRequest
    {
        MunicipioController _controller;
        [Fact(DisplayName = "Retorno BadRequest do metodo put municipio")]
        public async Task BadRequest_Put_MunicipioAsync()
        {
            #region variáveis
            var serviceMock = new Mock<IMunicipioservice>();
            Guid IdMunicipio = Guid.NewGuid();
            string NomeMunicipio = Faker.Address.City();
            int CodIBGEMunicipio = Faker.RandomNumber.Next(100000, 999999);
            Guid UfIDMunicipio = Guid.NewGuid();
            var _serviceMock = new Mock<IMunicipioservice>();
            #endregion

            _serviceMock.Setup(m => m.Put(It.IsAny<MunicipioDtoUpdate>()))
                        .ReturnsAsync(new MunicipioDtoUpdateResult
                        {
                            Id = IdMunicipio,
                            Nome = NomeMunicipio,
                            CodIBGE = CodIBGEMunicipio,
                            UfID = UfIDMunicipio,
                            UpdateAt = DateTime.UtcNow
                        });

            var municipio = new MunicipioDtoUpdate
            {
                Id = IdMunicipio,

                CodIBGE = CodIBGEMunicipio,
                UfID = UfIDMunicipio,
            };

            _controller = new MunicipioController(_serviceMock.Object);
            _controller.ModelState.AddModelError("Nome", "Nome é obrigatório");
            var result = await _controller.Put(municipio);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
