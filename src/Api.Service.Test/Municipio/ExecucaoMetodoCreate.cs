using System.Threading.Tasks;
using Api.Domain.Intereface.Services.Municipio;
using Moq;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class ExecucaoMetodoCreate : MunicipioBaseTest
    {
        private IMunicipioservice _service;
        private Mock<IMunicipioservice> _serviceMock;

        [Fact(DisplayName = "É possivel executar o método Create")]
        public async Task Teste_Execucao_Metodo_Create_Municipio()
        {
            _serviceMock = new Mock<IMunicipioservice>();
            _serviceMock.Setup(m => m.Post(MunicipioDtoCreate)).ReturnsAsync(MunicipioDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(MunicipioDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(NomeMunicipio, result.Nome);
            Assert.Equal(CodIBGEMunicipio, result.CodIBGE);
            Assert.Equal(UfIDMunicipio, result.UfID);
        }
    }
}
