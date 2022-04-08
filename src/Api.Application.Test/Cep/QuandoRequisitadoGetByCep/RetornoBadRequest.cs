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
    public class RetornoBadRequest
    {
        private CepControlller _controller;

        [Fact(DisplayName = "BadRequest Metodo Get de Cep por cep")]
        public async Task RetornoBadRequest_MetodoGetByCep()
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
                        .ReturnsAsync(new CepDto()
                        {
                            Id = IdCep,
                            Cep = Cep,
                            Logradouro = LogradouroCep,
                            Numero = NumeroCep,
                            MunicipioId = MunicipioId,
                            Municipio = new MunicipioDtoCompleto
                            {
                                Id = Guid.NewGuid(),
                                Nome = Faker.Address.City(),
                                CodIBGE = Faker.RandomNumber.Next(100000, 999999),
                                UfID = Guid.NewGuid(),
                                Uf = new UfDto
                                {
                                    Id = Guid.NewGuid(),
                                    Nome = Faker.Country.Name(),
                                    Sigla = Faker.Country.Name().Substring(1, 3)
                                }
                            }
                        });

            _controller = new CepControlller(_serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var result = await _controller.GetByCep(Cep);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
