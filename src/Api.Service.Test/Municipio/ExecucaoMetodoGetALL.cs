using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Intereface.Services.Municipio;
using Moq;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class ExecucaoMetodoGetALL : MunicipioBaseTest
    {
        private IMunicipioservice _service;
        private Mock<IMunicipioservice> _serviceMock;

        [Fact(DisplayName = "É possivel executar o método GETALL")]
        public async Task Teste_Execucao_Metodo_GETALL_Municipio()
        {
            _serviceMock = new Mock<IMunicipioservice>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(ListMunicipioDto);
            _service = _serviceMock.Object;

            var Listresult = await _service.GetAll();
            Assert.NotEmpty(Listresult);
            Assert.True(Listresult.Count() == 10);

            //Retorno Nulo
            var ListaNula = new List<MunicipioDto>();
            _serviceMock = new Mock<IMunicipioservice>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(ListaNula.AsEnumerable());
            _service = _serviceMock.Object;

            var resultnulo = await _service.Get(Guid.NewGuid());
            Assert.Null(resultnulo);
        }
    }
}
