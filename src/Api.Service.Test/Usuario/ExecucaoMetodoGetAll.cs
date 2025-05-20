using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Intereface.Services.Users;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class ExecucaoMetodoGetAll : UsuarioTest
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possivel executar o método GETALL")]
        public async Task E_Possivel_Executar_Metodo_GetALL()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(ListaUserDto);
            _service = _serviceMock.Object;

            var ListResult = await _service.GetAll();
            Assert.NotNull(ListResult);
            Assert.True(ListResult.Count() == 10);

            var listResultNula = new List<UserDto>();
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listResultNula.AsEnumerable);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.Empty(result);
            Assert.True(result.Count() == 0);
        }
    }
}
