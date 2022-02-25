using System.Threading.Tasks;
using Api.Domain.Intereface.Services.Users;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class ExecucaoMetodoUpdate : UsuarioTest
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possivel executar o método Update")]
        public async Task E_Possivel_Executar_Metodo_Update()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Post(UserDtoCreate)).ReturnsAsync(UserDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(UserDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(NomeUsuario, result.Name);
            Assert.Equal(EmailUsuario, result.Email);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Put(UserDtoUpdate)).ReturnsAsync(UserDtoUpdateResult);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.Put(UserDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.NotNull(resultUpdate.UpdatAt);
            Assert.Equal(NomeUsuarioAlterado, resultUpdate.Name);
            Assert.Equal(EmailUsuarioAlterado, resultUpdate.Email);
        }
    }
}
