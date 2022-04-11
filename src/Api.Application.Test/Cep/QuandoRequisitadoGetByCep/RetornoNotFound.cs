using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.Uf;
using Api.Domain.Intereface.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Cep.QuandoRequisitadoGetByCep
{
    public class RetornoNotFound
    {
        private CepController _controller;

        [Fact(DisplayName = "RetornoNotFound Metodo Get de Cep por cep")]
        public async Task RetornoNotFound_MetodoGetByCep()
        {
            #region  variaveis
            string Cep = Faker.RandomNumber.Next(000000, 999999).ToString();
            string LogradouroCep = Faker.Address.StreetAddress();
            string NumeroCep = Faker.RandomNumber.Next().ToString();
            Guid MunicipioId = new Guid("ea78590c-5276-4e6d-8840-83d984c3b40f");
            Guid IdCep = Guid.NewGuid();
            #endregion

            var _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.GetByCep(It.IsAny<string>()))
                        .Returns(Task.FromResult((CepDto)null));

            _controller = new CepController(_serviceMock.Object);

            var result = await _controller.GetByCep(Cep);
            Assert.True(result is NotFoundResult);
        }
    }
}
