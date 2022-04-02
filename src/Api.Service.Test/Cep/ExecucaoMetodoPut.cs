using System.Threading.Tasks;
using Api.Domain.Intereface.Services.Cep;
using Moq;
using Xunit;

namespace Api.Service.Test.Cep
{
    public class ExecucaoMetodoPut : CepBaseTeste
    {
        private ICepService _service;
        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName = "Teste do método put Cep")]
        public async Task Teste_Metodo_Put()
        {
            //BY ID
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Put(CepDtoUpdate)).ReturnsAsync(CepDtoUpdateResult);
            _service = _serviceMock.Object;

            var result = await _service.Put(CepDtoUpdate);
            Assert.NotNull(result);
            Assert.True(result.Id == IdCep);
            Assert.Equal(CepAlterado, result.Cep);
            Assert.Equal(LogradouroAlterado, result.Logradouro);
            Assert.Equal(NumeroAlterado, result.Numero);
            Assert.Equal(MunicipioId, result.MunicipioID);
            Assert.NotNull(result.UpdateAt);
        }
    }
}
