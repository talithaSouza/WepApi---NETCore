using System;
using System.Threading.Tasks;
using Api.Domain.Intereface.Services.Municipio;
using Moq;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class ExecucaoMetodoDelete : MunicipioBaseTest
    {
        private IMunicipioservice _service;
        private Mock<IMunicipioservice> _serviceMock;

        [Fact(DisplayName = "É possivel executar o método Delete")]
        public async Task Teste_Execucao_Metodo_Delete_Municipio()
        {
            #region Post P/Delete
            _serviceMock = new Mock<IMunicipioservice>();
            _serviceMock.Setup(m => m.Post(MunicipioDtoCreate)).ReturnsAsync(MunicipioDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(MunicipioDtoCreate);
            Assert.NotNull(result);
            Assert.NotNull(result.Id);
            Assert.Equal(NomeMunicipio, result.Nome);
            Assert.Equal(CodIBGEMunicipio, result.CodIBGE);
            Assert.Equal(UfIDMunicipio, result.UfID);
            #endregion

            _serviceMock = new Mock<IMunicipioservice>();
            _serviceMock.Setup(m => m.Delete(result.Id)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            bool vfDeletado = await _service.Delete(result.Id);
            Assert.True(vfDeletado);

            _serviceMock = new Mock<IMunicipioservice>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            vfDeletado = await _service.Delete(result.Id);
            Assert.False(vfDeletado);
        }
    }
}
