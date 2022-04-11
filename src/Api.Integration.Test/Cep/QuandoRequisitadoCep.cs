using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Domain.Dtos.Cep;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.Cep
{
    public class QuandoRequisitadoCep : BaseIntegration
    {
        private string _cep;
        private string _logradouro;
        private string _numero;
        private Guid _municipioId;

        [Fact]
        [Trait("CRUD", "Integração CEP")]
        public async Task CRUD_Cep()
        {
            await AdicionarToken();
            _cep = Faker.RandomNumber.Next(000000, 999999).ToString();
            _logradouro = Faker.Address.StreetAddress();
            _numero = Faker.RandomNumber.Next().ToString();
            _municipioId = new Guid("ea78590c-5276-4e6d-8840-83d984c3b40f");


            #region  POST
            var cepCreate = new CepDtoCreate()
            {
                Cep = _cep,
                Logradouro = _logradouro,
                Numero = _numero,
                MunicipioID = _municipioId
            };

            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(cepCreate), System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{hostApi}/cep", stringContent);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var resultValue = JsonConvert.DeserializeObject<CepDtoCreateResult>(jsonResult);

            Assert.Equal(response.StatusCode, HttpStatusCode.Created);
            Assert.NotNull(resultValue);
            Assert.NotNull(resultValue.CreateAt);
            Assert.Equal(_cep, resultValue.Cep);
            #endregion

            #region  PUT
            string logradouroAlterado = Faker.Address.StreetAddress();
            string numeroAltetado = Faker.RandomNumber.Next().ToString();
            var cepUpdate = new CepDtoUpdate()
            {
                Id = resultValue.Id,
                Cep = _cep,
                Logradouro = logradouroAlterado,
                Numero = numeroAltetado,
                MunicipioID = _municipioId
            };

            stringContent = new StringContent(JsonConvert.SerializeObject(cepUpdate), System.Text.Encoding.UTF8, "application/json");
            response = await client.PutAsync($"{hostApi}/cep", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            var resultUpdate = JsonConvert.DeserializeObject<CepDtoUpdateResult>(jsonResult);

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            Assert.NotNull(resultUpdate);
            Assert.NotNull(resultUpdate.UpdateAt);
            Assert.Equal(_cep, resultUpdate.Cep);
            Assert.Equal(logradouroAlterado, resultUpdate.Logradouro);
            #endregion

            #region  GET
            response = await client.GetAsync($"{hostApi}/cep/{resultUpdate.Id}");
            jsonResult = await response.Content.ReadAsStringAsync();
            var resultGet = JsonConvert.DeserializeObject<CepDtoUpdateResult>(jsonResult);

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            Assert.NotNull(resultGet);
            Assert.Equal(_cep, resultGet.Cep);
            Assert.Equal(logradouroAlterado, resultGet.Logradouro);
            Assert.Equal(numeroAltetado, resultGet.Numero);
            #endregion

            #region  GET BY CEP
            response = await client.GetAsync($"{hostApi}/cep/byCep/{resultUpdate.Cep}");
            jsonResult = await response.Content.ReadAsStringAsync();
            var resultGetByCep = JsonConvert.DeserializeObject<CepDtoUpdateResult>(jsonResult);

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            Assert.NotNull(resultGetByCep);
            Assert.Equal(_cep, resultGetByCep.Cep);
            Assert.Equal(logradouroAlterado, resultGetByCep.Logradouro);
            Assert.Equal(numeroAltetado, resultGetByCep.Numero);
            #endregion

            #region  DELETE
            response = await client.DeleteAsync($"{hostApi}/cep/{resultUpdate.Id}");
            jsonResult = await response.Content.ReadAsStringAsync();
            var resultDelete = JsonConvert.DeserializeObject<bool>(jsonResult);

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            Assert.True(resultDelete);
            #endregion
        }
    }
}
