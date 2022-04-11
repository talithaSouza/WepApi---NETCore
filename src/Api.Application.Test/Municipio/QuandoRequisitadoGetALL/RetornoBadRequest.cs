using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Intereface.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Municipio.QuandoRequisitadoGetALL
{
    public class RetornoBadRequest
    {
        private MunicipioController _controller;

        [Fact(DisplayName = "BadRequest Metodo GetALL de municipio")]
        public async Task RetornoBadRequest_MetodoGetALL()
        {
            var _serviceMock = new Mock<IMunicipioservice>();
            _serviceMock.Setup(m => m.GetAll())
                        .ReturnsAsync(new List<MunicipioDto>
                            {
                                new MunicipioDto()
                                {
                                    Id = Guid.NewGuid(),
                                    Nome = Faker.Address.City(),
                                    CodIBGE = Faker.RandomNumber.Next(100000, 999999),
                                    UfID = Guid.NewGuid()
                                },
                                new MunicipioDto()
                                {
                                    Id = Guid.NewGuid(),
                                    Nome = Faker.Address.City(),
                                    CodIBGE = Faker.RandomNumber.Next(100000, 999999),
                                    UfID = Guid.NewGuid()
                                },
                                new MunicipioDto()
                                {
                                    Id = Guid.NewGuid(),
                                    Nome = Faker.Address.City(),
                                    CodIBGE = Faker.RandomNumber.Next(100000, 999999),
                                    UfID = Guid.NewGuid()
                                }
                            });

            _controller = new MunicipioController(_serviceMock.Object);
            _controller.ModelState.AddModelError("", "Formato Inválido");

            var result = await _controller.GetlAll();
            Assert.True(result is BadRequestObjectResult);
        }
    }
}