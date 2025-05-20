using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Intereface.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Municipio.QuandoRequisitadoDelete
{
    public class RetornoOK
    {
        private MunicipioController _controller;

        [Fact(DisplayName = "Retorno OK Metodo Delete de municipio")]
        public async Task RetornoOk_Delete_Municipio()
        {
            var _serviceMock = new Mock<IMunicipioservice>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

            _controller = new MunicipioController(_serviceMock.Object);
            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);

            _controller = new MunicipioController(_serviceMock.Object);
            result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is OkObjectResult);


            var resultValue = ((OkObjectResult)result).Value;
            Assert.NotNull(resultValue);
            Assert.False((Boolean)resultValue);

        }
    }
}
