using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Uf;
using Api.Domain.Intereface.Services.Uf;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Uf.QuandoRequisitadoGET
{
    public class RequisicaoMetodoGet
    {
        private UfController _controller;

        [Fact(DisplayName = "Quando Requisitado Get Uf")]
        public async Task TestControllerUf_MetodoGET()
        {
            #region variáveis
            Guid Id = Guid.NewGuid();
            string Nome = Faker.Address.UsState();
            string Sigla = Faker.Address.UsState().Substring(1, 3);
            #endregion

            Mock<IUfService> _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>()))
                        .ReturnsAsync(new UfDto
                        {
                            Id = Id,
                            Nome = Nome,
                            Sigla = Sigla,
                        });

            _controller = new UfController(_serviceMock.Object);
            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as UfDto;
            Assert.NotNull(resultValue);
            Assert.True(resultValue.Id == Id);
            Assert.Equal(Nome, resultValue.Nome);
            Assert.Equal(Sigla, resultValue.Sigla);
        }
    }
}
