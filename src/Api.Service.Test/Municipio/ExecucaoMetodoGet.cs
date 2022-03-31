using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Intereface.Services.Municipio;
using Moq;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class ExecucaoMetodoGet : MunicipioBaseTest
    {
        private IMunicipioservice _service;
        private Mock<IMunicipioservice> _serviceMock;

        [Fact(DisplayName = "É possivel executar o método GET")]
        public async Task Teste_Execucao_Metodo_GET_Municipio()
        {
            _serviceMock = new Mock<IMunicipioservice>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(MunicipioDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(IdMunicipio);
            Assert.NotNull(result);
            Assert.Equal(NomeMunicipio, result.Nome);
            Assert.Equal(CodIBGEMunicipio, result.CodIBGE);
            Assert.Equal(UfIDMunicipio, result.UfID);
            Assert.True(result.Id == IdMunicipio);

            //Retorno Nulo
            _serviceMock = new Mock<IMunicipioservice>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((MunicipioDto)null));
            _service = _serviceMock.Object;

            var resultnulo = await _service.Get(Guid.NewGuid());
            Assert.Null(resultnulo);
        }
    }
}
