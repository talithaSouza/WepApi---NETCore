using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Intereface.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Municipio.QuandoRequisitadoDelete
{
    public class RetornoBadResquest
    {
        private MunicipioController _controller;

        [Fact(DisplayName = "BadRequest Metodo Delete de municipio")]
        public async Task RetornoBadRequest_Delete_Municipio()
        {
            var _serviceMock = new Mock<IMunicipioservice>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

            _controller = new MunicipioController(_serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}
