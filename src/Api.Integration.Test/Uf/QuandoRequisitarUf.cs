using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.Uf;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.Uf
{
    public class QuandoRequisitarUf : BaseIntegration
    {
        private string _sigla;
        private string _nome;

        [Fact(DisplayName = "Teste Integração UF")]
        [Trait("GETs", "Gets camada integração")]
        public async Task Eh_PossivelRealizarGetsUf()
        {
            await AdicionarToken();

            #region Get
            var response = await client.GetAsync($"{hostApi}/Uf/{new Guid("5ff1b59e-11e7-414d-827e-609dc5f7e333")}");
            var jsonGetResult = await response.Content.ReadAsStringAsync();
            var resultGet = JsonConvert.DeserializeObject<UfDto>(jsonGetResult);

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            Assert.NotNull(resultGet);
            Assert.Equal("Ceará", resultGet.Nome);
            Assert.Equal("CE", resultGet.Sigla);
            #endregion

            #region GetAll
            response = await client.GetAsync($"{hostApi}/Uf");
            var jsonResultGetAll = await response.Content.ReadAsStringAsync();
            var listResult = JsonConvert.DeserializeObject<IEnumerable<UfDto>>(jsonResultGetAll);

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            Assert.NotNull(listResult);
            Assert.True(listResult.Count() == 27);
            #endregion
        }


    }
}
