using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Intereface.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Municipio.QuandoRequisitadoGetComplete
{
    public class NotFound
    {
        private MunicipioController _controller;

        [Fact(DisplayName = "Retorno NotFound Metodo GetComplete de municipio")]
        public async Task RetornoNotFound_MetodoGetComplete()
        {
            var _serviceMock = new Mock<IMunicipioservice>();
            _serviceMock.Setup(m => m.GetCompleteById(It.IsAny<Guid>())).Returns(Task.FromResult((MunicipioDtoCompleto)null));
            _controller = new MunicipioController(_serviceMock.Object);


            var result = await _controller.GetCompleteById(Guid.NewGuid());
            Assert.True(result is NotFoundResult);


        }
    }
}
