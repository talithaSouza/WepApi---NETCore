using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Cep;
using Api.Domain.Intereface.Services.Cep;
using Moq;
using Xunit;

namespace Api.Service.Test.Cep
{
    public class ExecucaoMetodosGet : CepBaseTeste
    {
        private ICepService _service;
        private Mock<ICepService> _serviceMock;

        [Fact]
        [Trait("GETS", "GETById E GETByCep")]
        public async Task Teste_Metodos_Get()
        {
            //BY ID
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Get(IdCep)).ReturnsAsync(CepDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(IdCep);
            Assert.NotNull(result);
            Assert.Equal(Cep, result.Cep);
            Assert.Equal(LogradouroCep, result.Logradouro);
            Assert.Equal(NumeroCep, result.Numero);
            Assert.Equal(MunicipioId, result.MunicipioId);
            Assert.NotNull(result.Municipio);
            Assert.NotNull(result.Municipio.Uf);

            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((CepDto)null));
            _service = _serviceMock.Object;

            var record = await _service.Get(Guid.NewGuid());
            Assert.Null(record);

            //BY CEP
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.GetByCep(Cep)).ReturnsAsync(CepDto);
            _service = _serviceMock.Object;

            result = await _service.GetByCep(Cep);
            Assert.NotNull(result);
            Assert.Equal(Cep, result.Cep);
            Assert.Equal(LogradouroCep, result.Logradouro);
            Assert.Equal(NumeroCep, result.Numero);
            Assert.Equal(MunicipioId, result.MunicipioId);
            Assert.NotNull(result.Municipio);
            Assert.NotNull(result.Municipio.Uf);
            Assert.True(result.Id == IdCep);

            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.GetByCep(It.IsAny<string>())).Returns(Task.FromResult((CepDto)null));
            _service = _serviceMock.Object;

            record = await _service.GetByCep("62015-290");
            Assert.Null(record);
        }
    }
}
