using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test.Municipio
{
    public class MetodosCreate_Update_Delete : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;
        private MunicipioRepository _repository;

        public MetodosCreate_Update_Delete(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact]
        [Trait("Métodos Create, Update, Delete", "Município Entity")]
        public async Task Eh_Possivel_Realizar_Create_Update_Delete()
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

                //CREATE
                var _registroCriado = await _repository.InsertAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Nome, _registroCriado.Nome);
                Assert.Equal(_entity.CodIBGE, _registroCriado.CodIBGE);
                Assert.Equal(_entity.UfID, _registroCriado.UfID);
                Assert.False(_registroCriado.Id == Guid.Empty);

                //UPDATE
                _registroCriado.Nome = Faker.Country.Name();
                var _resgistroAtualizado = await _repository.UpdateAsync(_registroCriado);
                Assert.NotNull(_resgistroAtualizado);
                Assert.Equal(_registroCriado.Nome, _resgistroAtualizado.Nome);
                Assert.Equal(_registroCriado.CodIBGE, _resgistroAtualizado.CodIBGE);
                Assert.Equal(_registroCriado.UfID, _resgistroAtualizado.UfID);
                Assert.True(_registroCriado.Id == _resgistroAtualizado.Id);

                //Delete
                bool deletado = await _repository.DeleteAsync(_resgistroAtualizado.Id);
                Assert.True(deletado);
            }
        }
    }
}
