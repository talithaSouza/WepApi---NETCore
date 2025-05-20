using System;
using System.Threading.Tasks;
using Api.Domain.Intereface.Services.Cep;
using Moq;
using Xunit;

namespace Api.Service.Test.Cep
{
    public class ExecucaoMetodoDelete : CepBaseTeste
    {
        private ICepService _service;
        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName = "Teste do método post Delete")]
        public async Task Teste_Metodo_Delete()
        {
            #region POST P/Delete
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
            #endregion

            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _service = _serviceMock.Object;

            bool delete = await _service.Delete(result.Id);
            Assert.True(delete);

            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            delete = await _service.Delete(Guid.NewGuid());
            Assert.False(delete);
        }
    }
}
