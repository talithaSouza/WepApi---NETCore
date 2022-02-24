using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Intereface;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class UsuarioCrudCompleto : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public UsuarioCrudCompleto(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }


        [Fact(DisplayName = "CRUD de Usuário")]
        [Trait("CRUD", "UserEntity")]
        public async Task Eh_Possivel_Realizar_CRUD_Usuario()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UserRepository _repository = new UserRepository(context);
                UserEntity _entity = new UserEntity
                {
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email()
                };

                var _registroCriado = await _repository.InsertAsync(_entity);

                Assert.NotNull(_registroCriado);
                //             valor esperado,       valor atual
                Assert.Equal(_entity.Email, _registroCriado.Email);
                Assert.Equal(_entity.Name, _registroCriado.Name);
                Assert.False(_registroCriado.Id == Guid.Empty);


                //UPDATE
                _entity.Name = Faker.Name.First();
                var _registroAtualizado = await _repository.UpdateAsync(_entity);
                Assert.NotNull(_registroAtualizado);
                Assert.Equal(_entity.Email, _registroAtualizado.Email);
                Assert.Equal(_entity.Name, _registroAtualizado.Name);
                Assert.False(_registroAtualizado.Id == Guid.Empty);

                //Exist
                var _registroExistente = await _repository.ExistAsync(_registroAtualizado.Id);
                Assert.True(_registroExistente);

                //Select
                var _registroSelecionado = await _repository.SelectAsync(_registroAtualizado.Id);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_registroAtualizado.Email, _registroSelecionado.Email);
                Assert.Equal(_registroAtualizado.Name, _registroSelecionado.Name);

                //SelecALL
                var _todosOsRegistros = await _repository.SelectAsync();
                Assert.NotNull(_todosOsRegistros);
                Assert.True(_todosOsRegistros.Count() > 0);

                //REMOVE
                var _removeu = await _repository.DeleteAsync(_registroSelecionado.Id);
                Assert.True(_removeu);

                //FIND BY LOGIN
                var _usuarioPadrao = await _repository.FindByLogin("admin@email.com");
                Assert.NotNull(_usuarioPadrao);
                Assert.Equal("admin@email.com", _usuarioPadrao.Email);
                Assert.Equal("administrador", _usuarioPadrao.Name);
            }
        }
    }
}
