using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test.Municipio
{
    public class MetodosGet : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;
        private MunicipioRepository _repository;

        public MetodosGet(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact]
        [Trait("Métodos GET", "Município Entity")]
        public async Task Eh_Possivel_Realizar_Todos_Os_Gets()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                _repository = new MunicipioRepository(context);

                MunicipioEntity _entity = new MunicipioEntity()
                {
                    Nome = "Sobral",
                    CodIBGE = Faker.RandomNumber.Next(),
                    UfID = new Guid("5FF1B59E-11E7-414D-827E-609DC5F7E333"),
                };

                await _repository.InsertAsync(_entity);

                //GET Simples POR ID
                var _retornoById = await _repository.SelectAsync(_entity.Id);
                Assert.NotNull(_retornoById);
                Assert.True(_entity.Id == _retornoById.Id);
                Assert.Equal(_entity.Nome, _retornoById.Nome);
                Assert.Equal(_entity.CodIBGE, _retornoById.CodIBGE);
                Assert.Equal(_entity.UfID, _retornoById.UfID);
                Assert.Null(_entity.Uf);

                //GET Completo POR ID
                var _retornoCompletoById = await _repository.GetCompleteById(_entity.Id);
                Assert.NotNull(_retornoCompletoById);
                Assert.True(_entity.Id == _retornoCompletoById.Id);
                Assert.Equal(_entity.Nome, _retornoCompletoById.Nome);
                Assert.Equal(_entity.CodIBGE, _retornoCompletoById.CodIBGE);
                Assert.Equal(_entity.UfID, _retornoCompletoById.UfID);
                Assert.NotNull(_retornoCompletoById.Uf);

                //GET Completo POR Cod IBGE
                var _retornoByCodIBGE = await _repository.GetCompleteByIBGE(_entity.CodIBGE);
                Assert.NotNull(_retornoByCodIBGE);
                Assert.True(_entity.Id == _retornoByCodIBGE.Id);
                Assert.Equal(_entity.Nome, _retornoByCodIBGE.Nome);
                Assert.Equal(_entity.CodIBGE, _retornoByCodIBGE.CodIBGE);
                Assert.Equal(_entity.UfID, _retornoByCodIBGE.UfID);
                Assert.NotNull(_retornoByCodIBGE.Uf);

                //GET ALL
                var _listResult = await _repository.SelectAsync();
                Assert.NotNull(_listResult);
                Assert.True(_listResult.Count() > 0);
            }
        }

    }
}
