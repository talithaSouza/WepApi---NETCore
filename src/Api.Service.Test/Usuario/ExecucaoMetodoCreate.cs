using System.Threading.Tasks;
using Api.Domain.Intereface.Services.Users;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class ExecucaoMetodoCreate : UsuarioTest
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possivel executar o método Create")]
        public async Task E_Possivel_Executar_Metodo_Create()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Post(UserDtoCreate)).ReturnsAsync(UserDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(UserDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(NomeUsuario, result.Name);
            Assert.Equal(EmailUsuario, result.Email);
        }


    }
}
