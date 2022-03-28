using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test.Uf
{
    public class UfCrudCompleto : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public UfCrudCompleto(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact]
        [Trait("CRUD", "UFEntity")]
        public async Task Eh_Possivel_Realizar_CRUD_UF()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UfRepository _repository = new UfRepository(context);

                UfEntity Uf = new UfEntity()
                {
                    Id = new Guid("5ff1b59e-11e7-414d-827e-609dc5f7e333"),
                    Sigla = "CE",
                    Nome = "Ceará"
                };

                //GET
                var retornoPorID = await _repository.SelectAsync(Uf.Id);
                Assert.NotNull(retornoPorID);
                Assert.Equal(Uf.Sigla, retornoPorID.Sigla);
                Assert.Equal(Uf.Nome, retornoPorID.Nome);

                //GET ALL
                var listaRetorno = await _repository.SelectAsync();
                Assert.NotNull(listaRetorno);
                Assert.True(listaRetorno.Count() > 0);

                //INSERT
                var _novoUF = new UfEntity()
                {
                    Sigla = Faker.Country.TwoLetterCode(),
                    Nome = Faker.Country.Name()
                };

                var _registroCriado = await _repository.InsertAsync(_novoUF);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_novoUF.Sigla, _registroCriado.Sigla);
                Assert.Equal(_novoUF.Nome, _registroCriado.Nome);

                //UPDATE
                _registroCriado.Sigla = Faker.Country.TwoLetterCode();
                var _resgistroAtualizado = await _repository.UpdateAsync(_registroCriado);
                Assert.NotNull(_resgistroAtualizado);
                Assert.Equal(_registroCriado.Nome, _resgistroAtualizado.Nome);
                Assert.NotNull(_resgistroAtualizado.UpdateAt);
                Assert.True(_registroCriado.Id == _resgistroAtualizado.Id);

                //DELETE
                bool delete = await _repository.DeleteAsync(_resgistroAtualizado.Id);
                Assert.True(delete);
            }
        }
    }
}
