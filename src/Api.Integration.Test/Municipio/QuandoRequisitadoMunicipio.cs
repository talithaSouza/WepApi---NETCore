using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Domain.Dtos.Municipio;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.Municipio
{
    public class QuandoRequisitadoMunicipio : BaseIntegration
    {
        //private Guid _id;
        private string _nome;
        private int _codIBGE;
        private Guid _ufID;

        [Fact(DisplayName = "Teste de Integração Municipio")]
        [Trait("CRUD", "Integração municipio")]
        public async Task CRUD_Municipio()
        {
            await AdicionarToken();
            _nome = Faker.Address.City();
            _codIBGE = Faker.RandomNumber.Next(100000, 999999);
            _ufID = new Guid("5ff1b59e-11e7-414d-827e-609dc5f7e333");

            #region Post
            var municipioDto = new MunicipioDtoCreate()
            {
                Nome = _nome,
                CodIBGE = _codIBGE,
                UfID = _ufID
            };
            var response = await client.PostAsync($"{hostApi}/Municipio", new StringContent(JsonConvert.SerializeObject(municipioDto), System.Text.Encoding.UTF8, "application/json"));
            var jsonResult = await response.Content.ReadAsStringAsync();
            var resultValue = JsonConvert.DeserializeObject<MunicipioDtoCreateResult>(jsonResult);

            Assert.True(HttpStatusCode.Created == response.StatusCode);
            Assert.NotNull(resultValue);
            Assert.Equal(_nome, resultValue.Nome);
            Assert.Equal(_codIBGE, resultValue.CodIBGE);
            Assert.Equal(_ufID, resultValue.UfID);
            #endregion

            #region PUT
            string nomeAlterado = Faker.Address.City();
            int CodIBGEAlterado = Faker.RandomNumber.Next(100000, 999999);

            var municipioUpdate = new MunicipioDtoUpdate()
            {
                Id = resultValue.Id,
                Nome = nomeAlterado,
                CodIBGE = CodIBGEAlterado,
                UfID = resultValue.UfID
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(municipioUpdate), System.Text.Encoding.UTF8, "application/json");
            response = await client.PutAsync($"{hostApi}/municipio", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            var resultUpdate = JsonConvert.DeserializeObject<MunicipioDtoUpdateResult>(jsonResult);

            Assert.True(HttpStatusCode.OK == response.StatusCode);
            Assert.NotNull(resultUpdate);
            Assert.Equal(nomeAlterado, resultUpdate.Nome);
            Assert.Equal(CodIBGEAlterado, resultUpdate.CodIBGE);
            Assert.Equal(resultValue.Id, resultUpdate.Id);
            #endregion

            #region Get
            response = await client.GetAsync($"{hostApi}/municipio/{resultUpdate.Id}");
            jsonResult = await response.Content.ReadAsStringAsync();
            var resultGet = JsonConvert.DeserializeObject<MunicipioDto>(jsonResult);

            Assert.True(HttpStatusCode.OK == response.StatusCode);
            Assert.NotNull(resultGet);
            Assert.Equal(resultUpdate.Nome, resultGet.Nome);
            Assert.Equal(resultUpdate.CodIBGE, resultGet.CodIBGE);
            #endregion

            #region GetComplete
            response = await client.GetAsync($"{hostApi}/municipio/complete/{resultUpdate.Id}");
            jsonResult = await response.Content.ReadAsStringAsync();
            var resultGetComplete = JsonConvert.DeserializeObject<MunicipioDtoCompleto>(jsonResult);

            Assert.True(HttpStatusCode.OK == response.StatusCode);
            Assert.NotNull(resultGetComplete);
            Assert.Equal(resultUpdate.Nome, resultGetComplete.Nome);
            Assert.Equal(resultUpdate.CodIBGE, resultGetComplete.CodIBGE);
            Assert.NotNull(resultGetComplete.Uf);
            #endregion

            #region GetComplete By IGBE
            response = await client.GetAsync($"{hostApi}/municipio/completeByIbge/{resultUpdate.CodIBGE}");
            jsonResult = await response.Content.ReadAsStringAsync();
            var resultGetCompleteIBGE = JsonConvert.DeserializeObject<MunicipioDtoCompleto>(jsonResult);

            Assert.True(HttpStatusCode.OK == response.StatusCode);
            Assert.NotNull(resultGetCompleteIBGE);
            Assert.Equal(resultUpdate.Nome, resultGetCompleteIBGE.Nome);
            Assert.Equal(resultUpdate.CodIBGE, resultGetCompleteIBGE.CodIBGE);
            Assert.NotNull(resultGetCompleteIBGE.Uf);
            #endregion

            #region GetAll
            response = await client.GetAsync($"{hostApi}/municipio");
            jsonResult = await response.Content.ReadAsStringAsync();
            var listResult = JsonConvert.DeserializeObject<IEnumerable<MunicipioDtoCompleto>>(jsonResult);

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            Assert.NotNull(listResult);
            Assert.True(listResult.Count() > 0);
            Assert.True(listResult.FirstOrDefault(x => x.Id == resultGet.Id) != null);
            #endregion

            #region Delete
            response = await client.DeleteAsync($"{hostApi}/municipio/{resultGet.Id}");
            jsonResult = await response.Content.ReadAsStringAsync();
            var resultDelete = JsonConvert.DeserializeObject<bool>(jsonResult);

            Assert.True(resultDelete);
            response = await client.GetAsync($"{hostApi}/municipio/{resultGet.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            #endregion
        }
    }
}
