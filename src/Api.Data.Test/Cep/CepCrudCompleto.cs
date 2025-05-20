using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test.Cep
{
    public class CepCrudCompleto : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;
        private CepRepository _repository;

        public CepCrudCompleto(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact]
        [Trait("CRUD", "CEP Entity")]
        public async Task Eh_Possivel_Realizar_Crud()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                _repository = new CepRepository(context);

                CEPEntity _entity = new CEPEntity()
                {
                    Cep = Faker.RandomNumber.Next(000000, 999999).ToString(),
                    Logradouro = Faker.Address.StreetAddress(),
                    Numero = Faker.RandomNumber.Next().ToString(),
                    MunicipioId = new Guid("ea78590c-5276-4e6d-8840-83d984c3b40f")
                };

                //CREATE
                var _registroCriado = await _repository.InsertAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Cep, _registroCriado.Cep);
                Assert.Equal(_entity.Logradouro, _registroCriado.Logradouro);
                Assert.Equal(_entity.Numero, _registroCriado.Numero);
                Assert.False(_registroCriado.Id == Guid.Empty);

                //UPDATE
                _registroCriado.Logradouro = Faker.Address.StreetAddress();
                var _resgistroAtualizado = await _repository.UpdateAsync(_registroCriado);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Cep, _registroCriado.Cep);
                Assert.Equal(_entity.Logradouro, _registroCriado.Logradouro);
                Assert.Equal(_entity.Numero, _registroCriado.Numero);
                Assert.True(_registroCriado.Id == _resgistroAtualizado.Id);

                //Get por Id
                var _retornoById = await _repository.SelectAsync(_resgistroAtualizado.Id);
                Assert.NotNull(_retornoById);
                Assert.True(_resgistroAtualizado.Id == _retornoById.Id);
                Assert.Equal(_resgistroAtualizado.Cep, _retornoById.Cep);
                Assert.Equal(_resgistroAtualizado.Logradouro, _retornoById.Logradouro);
                Assert.Equal(_resgistroAtualizado.Numero, _retornoById.Numero);
                Assert.Null(_entity.Municipio);

                //GET por CEP
                var _retornoByCEP = await _repository.SelectAsync(_resgistroAtualizado.Cep);
                Assert.NotNull(_retornoById);
                Assert.True(_resgistroAtualizado.Id == _retornoByCEP.Id);
                Assert.Equal(_resgistroAtualizado.Cep, _retornoByCEP.Cep);
                Assert.Equal(_resgistroAtualizado.Logradouro, _retornoByCEP.Logradouro);
                Assert.Equal(_resgistroAtualizado.Numero, _retornoByCEP.Numero);
                Assert.NotNull(_retornoByCEP.Municipio);
                Assert.NotNull(_retornoByCEP.Municipio.Uf);

                //GET ALL
                var listaCeps = await _repository.SelectAsync();
                Assert.NotNull(listaCeps);
                Assert.True(listaCeps.Count() > 0);

                //DELETE
                bool delete = await _repository.DeleteAsync(_resgistroAtualizado.Id);
                Assert.True(delete);
            }
        }

    }
}
