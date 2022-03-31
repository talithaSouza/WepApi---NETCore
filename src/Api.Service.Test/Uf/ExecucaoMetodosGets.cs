using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Uf;
using Api.Domain.Intereface.Services.Uf;
using Moq;
using Xunit;

namespace Api.Service.Test.Uf
{
    public class ExecucaoMetodosGets : UfBaseTest
    {
        private IUfService _service;
        private Mock<IUfService> _mock;

        [Fact(DisplayName = "É possivel executar o métodos Gets")]
        public async Task Teste_Execucao_Metodos_Gets_UF()
        {
            _mock = new Mock<IUfService>();

            //GET
            _mock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(ufDto);
            _service = _mock.Object;

            var result = await _service.Get(IdUf);
            Assert.True(result.Id == IdUf);
            Assert.Equal(NomeUf, result.Nome);
            Assert.Equal(SiglaUf, result.Sigla);

            //Get Com retorno nulo
            _mock = new Mock<IUfService>();
            _mock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UfDto)null));
            _service = _mock.Object;
            result = await _service.Get(IdUf);
            Assert.Null(result);

            //GETALL
            _mock = new Mock<IUfService>();
            _mock.Setup(m => m.GetAll()).ReturnsAsync(ListaUfDto);
            _service = _mock.Object;

            var listResult = await _service.GetAll();
            Assert.NotEmpty(listResult);
            Assert.True(listResult.Count() == 10);

            //GETALL Com Retorno nulo
            _mock = new Mock<IUfService>();
            var listResultNula = new List<UfDto>();
            _mock.Setup(m => m.GetAll()).ReturnsAsync(listResultNula.AsEnumerable);
            _service = _mock.Object;

            var resultNulo = await _service.GetAll();
            Assert.Empty(resultNulo);
            Assert.True(resultNulo.Count() == 0);

        }
    }
}
