using System;
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
                    Name = "teste",
                    Email = "teste@email.com"
                };

                var _registroCriado = await _repository.InsertAsync(_entity);

                Assert.NotNull(_registroCriado);
                Assert.Equal("teste@email.com", _registroCriado.Email);
                Assert.Equal("teste", _registroCriado.Name);
                Assert.False(_registroCriado.Id == Guid.Empty);
            }
        }
    }
}
