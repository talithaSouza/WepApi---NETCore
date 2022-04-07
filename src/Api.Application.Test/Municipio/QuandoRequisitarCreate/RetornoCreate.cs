using System;
using Api.Application.Controllers;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Intereface.Services.Municipio;
using Api.Domain.Intereface.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Municipio.QuandoRequisitarCreate
{
    public class RetornoCreate
    {
        private MunicipioController _controller;

        [Fact(DisplayName = "É possivel Realizar o Created de municipio")]
        public async void Eh_Possivel_Invocar_A_Controller_Created()
        {
            var serviceMock = new Mock<IMunicipioservice>();
            Guid IdMunicipio = Guid.NewGuid();
            string NomeMunicipio = Faker.Address.City();
            int CodIBGEMunicipio = Faker.RandomNumber.Next(100000, 999999);
            Guid UfIDMunicipio = Guid.NewGuid();

            serviceMock.Setup(m => m.Post(It.IsAny<MunicipioDtoCreate>()))
            .ReturnsAsync(new MunicipioDtoCreateResult()
            {
                Id = IdMunicipio,
                Nome = NomeMunicipio,
                CodIBGE = CodIBGEMunicipio,
                UfID = UfIDMunicipio,
                CreateAt = DateTime.UtcNow
            });

            _controller = new MunicipioController(serviceMock.Object);

            //Mocando o endereço URL da API para o retorno do guid na rota: como definido na controller
            Mock<IUrlHelper> urlMock = new Mock<IUrlHelper>();
            urlMock.Setup(m => m.Link(It.IsAny<String>(), It.IsAny<object>())).Returns(Faker.Internet.Url());
            _controller.Url = urlMock.Object;

            var municipioCreate = new MunicipioDtoCreate()
            {
                Nome = NomeMunicipio,
                CodIBGE = CodIBGEMunicipio,
                UfID = UfIDMunicipio,
            };

            var result = await _controller.Post(municipioCreate);
            Assert.True(result is CreatedResult);

            /*var resultValue = ((CreatedResult)result).Value as UserDtoCreateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(userCreate.Name, resultValue.Name);
            Assert.Equal(userCreate.Email, resultValue.Email);*/
        }
    }
}
