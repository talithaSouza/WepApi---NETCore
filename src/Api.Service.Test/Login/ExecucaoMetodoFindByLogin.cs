using System;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Intereface.Services.Users;
using Moq;
using Xunit;

namespace Api.Service.Test.Login
{
    public class ExecucaoMetodoFindByLogin
    {
        private ILoginService _service;
        private Mock<ILoginService> _serviceMock;

        [Fact(DisplayName = "É possivel executar o método login")]
        public async Task TesteMetodoFindByLogin()
        {
            var email = Faker.Internet.Email();
            var objectRetorno = new
            {
                authenticated = true,
                created = DateTime.UtcNow,
                expiration = DateTime.UtcNow.AddHours(8),
                acessToken = Guid.NewGuid(),
                userName = Faker.Internet.Email(),
                message = "Usuario logado com sucesso"
            };

            var loginDto = new LoginDTO()
            {
                Email = email
            };

            _serviceMock = new Mock<ILoginService>();
            _serviceMock.Setup(m => m.FindByLogin(loginDto)).ReturnsAsync(objectRetorno);
            _service = _serviceMock.Object;

            var result = await _service.FindByLogin(loginDto);
            Assert.NotNull(result);
        }

    }
}
