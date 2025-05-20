using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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

            #region POST
            //POST
            var response = await PostJsonAsync(userDto, $"{hostApi}/users", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var registroPost = JsonConvert.DeserializeObject<UserDtoCreateResult>(postResult);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(_name, registroPost.Name);
            Assert.Equal(_email, registroPost.Email);
            Assert.NotNull(registroPost.Id);
            #endregion

            #region GETALL
            //GET
            response = await client.GetAsync($"{hostApi}/users");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var lista = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(jsonResult);
            Assert.NotNull(lista);
            Assert.True(lista.Count() > 0);
            Assert.True(lista.FirstOrDefault(x => x.Id == registroPost.Id) != null);
            #endregion

            #region PUT
            //PUT
            var userUpdateDto = new UserDtoUpdate()
            {
                Id = registroPost.Id,
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email()
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(userUpdateDto), Encoding.UTF8, "application/json");
            response = await client.PutAsync($"{hostApi}/users", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroAtualizado = JsonConvert.DeserializeObject<UserDtoUpdateResult>(jsonResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(registroAtualizado);
            Assert.Equal(registroPost.Id, registroAtualizado.Id);
            Assert.NotEqual(registroPost.Name, registroAtualizado.Name);
            Assert.NotEqual(registroPost.Email, registroAtualizado.Email);
            #endregion

            #region  GET POR ID
            //GET POR ID
            response = await client.GetAsync($"{hostApi}/users/{registroAtualizado.Id}");
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroRetornado = JsonConvert.DeserializeObject<UserDto>(jsonResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(registroRetornado);
            Assert.Equal(registroAtualizado.Id, registroRetornado.Id);
            Assert.Equal(registroAtualizado.Name, registroRetornado.Name);
            Assert.Equal(registroAtualizado.Email, registroRetornado.Email);
            #endregion

            #region  DELETE
            //DELETE
            response = await client.DeleteAsync($"{hostApi}/users/{registroRetornado.Id}");
            jsonResult = await response.Content.ReadAsStringAsync();
            var boolDeletado = JsonConvert.DeserializeObject<bool>(jsonResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(boolDeletado);

            //GET ID DEPOIS DO DELETE
            response = await client.GetAsync($"{hostApi}/users/{registroRetornado.Id}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            #endregion
        }
    }
}
