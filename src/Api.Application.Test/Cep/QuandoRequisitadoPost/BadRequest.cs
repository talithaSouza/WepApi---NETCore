using System;
using Api.Application.Controllers;
using Api.Domain.Dtos.Cep;
using Api.Domain.Intereface.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Cep.QuandoRequisitadoPost
{
    public class BadRequest
    {
        private CepController _controller;

        [Fact(DisplayName = "Retorno BadRequest Created de Cep")]
        public async void BadRequest_Created()
        {
            #region  variaveis
            string Cep = Faker.RandomNumber.Next(000000, 999999).ToString();
            string LogradouroCep = Faker.Address.StreetAddress();
            string NumeroCep = Faker.RandomNumber.Next().ToString();
            Guid MunicipioId = new Guid("ea78590c-5276-4e6d-8840-83d984c3b40f");
            Guid IdCep = Guid.NewGuid();
            #endregion

            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Post(It.IsAny<CepDtoCreate>()))
            .ReturnsAsync(new CepDtoCreateResult()
            {
                Id = IdCep,
                Cep = Cep,
                Logradouro = LogradouroCep,
                Numero = NumeroCep,
                MunicipioID = MunicipioId,
                CreateAt = DateTime.UtcNow
            });

            _controller = new CepController(serviceMock.Object);
            _controller.ModelState.AddModelError("ID", "Formato Inválido");

            //Mocando o endereço URL da API para o retorno do guid na rota: como definido na controller
            Mock<IUrlHelper> urlMock = new Mock<IUrlHelper>();
            urlMock.Setup(m => m.Link(It.IsAny<String>(), It.IsAny<object>())).Returns(Faker.Internet.Url());
            _controller.Url = urlMock.Object;


            var cepCreate = new CepDtoCreate()
            {
                Cep = Cep,
                Logradouro = LogradouroCep,
                Numero = NumeroCep,
                MunicipioID = MunicipioId
            };

            var result = await _controller.Post(cepCreate);
            Assert.True(result is BadRequestObjectResult);

        }
    }
}
