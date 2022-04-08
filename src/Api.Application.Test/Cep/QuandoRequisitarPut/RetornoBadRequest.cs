using System;
using Api.Application.Controllers;
using Api.Domain.Dtos.Cep;
using Api.Domain.Intereface.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Cep.QuandoRequisitarPut
{
    public class RetornoBadRequest
    {
        private CepControlller _controller;

        [Fact(DisplayName = "Retorno BadRequest Upadate de Cep")]
        public async void BadRequest_Update()
        {
            #region  variaveis
            string Cep = Faker.RandomNumber.Next(000000, 999999).ToString();
            string LogradouroCep = Faker.Address.StreetAddress();
            string NumeroCep = Faker.RandomNumber.Next().ToString();
            Guid MunicipioId = new Guid("ea78590c-5276-4e6d-8840-83d984c3b40f");
            Guid IdCep = Guid.NewGuid();
            #endregion

            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Put(It.IsAny<CepDtoUpdate>()))
            .ReturnsAsync(new CepDtoUpdateResult()
            {
                Id = IdCep,
                Cep = Cep,
                Logradouro = LogradouroCep,
                Numero = NumeroCep,
                MunicipioID = MunicipioId,
                UpdateAt = DateTime.UtcNow
            });

            _controller = new CepControlller(serviceMock.Object);
            _controller.ModelState.AddModelError("ID", "Formato Inválido");


            var cepUpdate = new CepDtoUpdate()
            {
                Id = IdCep,
                Cep = Cep,
                Logradouro = LogradouroCep,
                Numero = NumeroCep,
                MunicipioID = MunicipioId
            };

            var result = await _controller.Put(cepUpdate);
            Assert.True(result is BadRequestObjectResult);

        }
    }
}
