using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Intereface.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Cep.QuandoRequisitadoDelete
{
    public class RetornoOk
    {
        private CepControlller _controller;

        [Fact(DisplayName = "Ok Metodo Delete de municipio")]
        public async Task RetornoBadRequest_Delete_Cep()
        {
            var _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

            _controller = new CepControlller(_serviceMock.Object);

            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

        }
    }
}
