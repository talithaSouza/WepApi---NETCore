using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Intereface.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Municipio.QuandoRequisitadoGetCompleteByIBGE
{
    public class RetornoNotFound
    {
        private MunicipioController _controller;

        [Fact(DisplayName = "Retorno NotFound Metodo Get de municipio")]
        public async Task RetornoNotFound_MetodoGet()
        {
            var _serviceMock = new Mock<IMunicipioservice>();
            _serviceMock.Setup(m => m.GetCompleteByIBGE(It.IsAny<int>())).Returns(Task.FromResult((MunicipioDtoCompleto)null));
            _controller = new MunicipioController(_serviceMock.Object);

            var result = await _controller.GetCompleteByIBGE(Faker.RandomNumber.Next(100000, 9999999));
            Assert.True(result is NotFoundResult);
        }
    }
}
