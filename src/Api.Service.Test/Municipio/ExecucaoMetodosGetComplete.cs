using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Intereface.Services.Municipio;
using Moq;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class ExecucaoMetodosGetComplete : MunicipioBaseTest
    {
        private IMunicipioservice _service;
        private Mock<IMunicipioservice> _serviceMock;

        [Fact(DisplayName = "É possivel executar os métodos GET Completos")]
        [Trait("GETs Completos", "Por Id e CodIBGE")]
        public async void Teste_Execucao_Metodo_GET_Municipio()
        {
            _serviceMock = new Mock<IMunicipioservice>();
            _serviceMock.Setup(m => m.GetCompleteById(It.IsAny<Guid>())).ReturnsAsync(MunicipioDtoCompleto);
            _service = _serviceMock.Object;

            var resultCompleto = await _service.GetCompleteById(IdMunicipio);
            Assert.NotNull(resultCompleto);
            Assert.Equal(NomeMunicipio, resultCompleto.Nome);
            Assert.Equal(CodIBGEMunicipio, resultCompleto.CodIBGE);
            Assert.Equal(UfIDMunicipio, resultCompleto.UfID);
            Assert.True(resultCompleto.Id == IdMunicipio);
            Assert.NotNull(resultCompleto.Uf);

            //retorno nulo por Id
            _serviceMock = new Mock<IMunicipioservice>();
            _serviceMock.Setup(m => m.GetCompleteById(It.IsAny<Guid>())).Returns(Task.FromResult((MunicipioDtoCompleto)null));
            _service = _serviceMock.Object;

            var resultCompletoNulo = await _service.GetCompleteById(IdMunicipio);
            Assert.Null(resultCompletoNulo);


            //Retorno Completo Por IBGE
            _serviceMock = new Mock<IMunicipioservice>();
            _serviceMock.Setup(m => m.GetCompleteByIBGE(It.IsAny<int>())).ReturnsAsync(MunicipioDtoCompleto);
            _service = _serviceMock.Object;

            var resultCompletoIBGE = await _service.GetCompleteByIBGE(CodIBGEMunicipio);
            Assert.NotNull(resultCompletoIBGE);
            Assert.Equal(NomeMunicipio, resultCompletoIBGE.Nome);
            Assert.Equal(CodIBGEMunicipio, resultCompletoIBGE.CodIBGE);
            Assert.Equal(UfIDMunicipio, resultCompletoIBGE.UfID);
            Assert.True(resultCompletoIBGE.Id == IdMunicipio);
            Assert.NotNull(resultCompletoIBGE.Uf);

            // retorno nulo por Id
            _serviceMock = new Mock<IMunicipioservice>();
            _serviceMock.Setup(m => m.GetCompleteByIBGE(It.IsAny<int>())).Returns(Task.FromResult((MunicipioDtoCompleto)null));
            _service = _serviceMock.Object;

            var resultCompletoIBGENulo = await _service.GetCompleteByIBGE(CodIBGEMunicipio);
            Assert.Null(resultCompletoIBGENulo);
        }
    }
}
