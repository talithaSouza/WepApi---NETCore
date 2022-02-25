using System;
using System.Threading.Tasks;
using Api.Domain.Intereface.Services.Users;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class ExecucaoMetodoDelete : UsuarioTest
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possivel executar o método Delete")]
        public async Task E_Possivel_Executar_Metodo_Delete()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var result = await _service.Delete(IdUsuario);
            Assert.True(result);
        }
    }
}
