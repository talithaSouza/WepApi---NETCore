using System.Threading.Tasks;
using Api.Domain.Intereface.Services.Municipio;
using Moq;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class ExecucaoMetodoUpdate : MunicipioBaseTest
    {
        private IMunicipioservice _service;
        private Mock<IMunicipioservice> _serviceMock;

        [Fact(DisplayName = "É possivel executar o método Update")]
        public async Task Teste_Execucao_Metodo_Update_Municipio()
        {
            _serviceMock = new Mock<IMunicipioservice>();
            _serviceMock.Setup(m => m.Put(MunicipioDtoUpdate)).ReturnsAsync(MunicipioDtoUpdateResult);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.Put(MunicipioDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(NomeMunicipioAlterado, resultUpdate.Nome);
            Assert.Equal(CodIBGEMunicipioAlterado, resultUpdate.CodIBGE);
            Assert.Equal(UfIDMunicipioAlterado, resultUpdate.UfID);
            Assert.Equal(IdMunicipio, resultUpdate.Id);
            Assert.NotNull(resultUpdate.UpdateAt);
        }
    }
}
