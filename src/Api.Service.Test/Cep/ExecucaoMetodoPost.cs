using System;
using System.Threading.Tasks;
using Api.Domain.Intereface.Services.Cep;
using Moq;
using Xunit;

namespace Api.Service.Test.Cep
{
    public class ExecucaoMetodoPost : CepBaseTeste
    {
        private ICepService _service;
        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName = "Teste do método post Cep")]
        public async Task Teste_Metodo_Pos()
        {
            //BY ID
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Post(CepDtoCreate)).ReturnsAsync(CepDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(CepDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(Cep, result.Cep);
            Assert.Equal(LogradouroCep, result.Logradouro);
            Assert.Equal(NumeroCep, result.Numero);
            Assert.Equal(MunicipioId, result.MunicipioID);
            Assert.NotNull(result.CreateAt);

        }
    }
}
