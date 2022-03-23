using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.Usuario
{
    public class QuandoRequisitarUsuario : BaseIntegration
    {
        private string _name;
        private string _email;
        [Fact]
        public async Task Eh_Possivel_Realizar_CRUD_Usuario()
        {
            await AdicionarToken();
            _name = Faker.Name.FullName();
            _email = Faker.Internet.Email();

            var userDto = new UserDtoCreate()
            {
                Name = _name,
                Email = _email,
            };

            var response = await PostJsonAsync(userDto, $"{hostApi}/users", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var registroPost = JsonConvert.DeserializeObject<UserDtoCreateResult>(postResult);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(_name, registroPost.Name);
            Assert.Equal(_email, registroPost.Email);
            Assert.NotNull(registroPost.Id);
        }
    }
}
