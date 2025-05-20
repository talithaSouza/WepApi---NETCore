using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.Cep;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class CepMapper : BaseTesteService
    {

        [Fact(DisplayName = "É Possivel Mapear os Modelos")]
        public void Teste_Mapper_Modelos_Cep()
        {
            var model = new CepModel()
            {
                ID = Guid.NewGuid(),
                Cep = Faker.RandomNumber.Next(10000, 99999).ToString(),
                Logradouro = Faker.Address.StreetName(),
                Numero = Faker.RandomNumber.Next().ToString(),
                MunicipioID = Guid.NewGuid(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
            };

            var listaEntity = new List<CEPEntity>();
            for (int i = 0; i <= 5; i++)
            {
                listaEntity.Add(new CEPEntity()
                {
                    Cep = Faker.RandomNumber.Next(10000, 99999).ToString(),
                    Logradouro = Faker.Address.StreetName(),
                    Numero = Faker.RandomNumber.Next().ToString(),
                    MunicipioId = Guid.NewGuid(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    Municipio = new MunicipioEntity()
                    {
                        Nome = Faker.Address.City(),
                        CodIBGE = Faker.RandomNumber.Next(100000, 999999),
                        UfID = Guid.NewGuid(),
                        CreateAt = DateTime.UtcNow,
                        UpdateAt = DateTime.UtcNow,
                        Uf = new UfEntity()
                        {
                            Id = Guid.NewGuid(),
                            Nome = Faker.Address.UsState(),
                            Sigla = Faker.Address.UsState().Substring(1, 3),
                        }
                    }
                });
            }

            //MODEL => ENTITY
            var entity = Mapper.Map<CEPEntity>(model);
            Assert.Equal(model.ID, entity.Id);
            Assert.Equal(model.Cep, entity.Cep);
            Assert.Equal(model.Logradouro, entity.Logradouro);
            Assert.Equal(model.Numero, entity.Numero);
            Assert.Equal(model.MunicipioID, entity.MunicipioId);
            Assert.Equal(model.CreateAt, entity.CreateAt);
            Assert.Equal(model.UpdateAt, entity.UpdateAt);

            //ENTITY => DTO
            var cepDto = Mapper.Map<CepDto>(entity);
            Assert.True(entity.Id == cepDto.Id);
            Assert.True(entity.Cep == cepDto.Cep);
            Assert.Equal(entity.Logradouro, cepDto.Logradouro);
            Assert.Equal(entity.Numero, cepDto.Numero);
            Assert.Equal(entity.MunicipioId, cepDto.MunicipioId);

            var listDto = Mapper.Map<List<CepDto>>(listaEntity);
            Assert.True(listDto.Count() == listaEntity.Count());

            for (int i = 0; i < listDto.Count(); i++)
            {
                Assert.Equal(listDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listDto[i].Cep, listaEntity[i].Cep);
                Assert.Equal(listDto[i].Logradouro, listaEntity[i].Logradouro);
                Assert.Equal(listDto[i].Numero, listaEntity[i].Numero);
                Assert.Equal(listDto[i].MunicipioId, listaEntity[i].MunicipioId);
            }

            //ENTITY => DTOCompleto
            var cepDtoCompleto = Mapper.Map<CepDto>(listaEntity.FirstOrDefault());
            Assert.Equal(listaEntity.FirstOrDefault().Id, cepDtoCompleto.Id);
            Assert.Equal(listaEntity.FirstOrDefault().Cep, cepDtoCompleto.Cep);
            Assert.Equal(listaEntity.FirstOrDefault().Logradouro, cepDtoCompleto.Logradouro);
            Assert.Equal(listaEntity.FirstOrDefault().MunicipioId, cepDtoCompleto.MunicipioId);
            Assert.NotNull(cepDtoCompleto.Municipio);
            Assert.NotNull(cepDtoCompleto.Municipio.Uf);

            //entity =>DTOCreateResult
            var cepDtoCreateResult = Mapper.Map<CepDtoCreateResult>(entity);
            Assert.Equal(entity.Id, cepDtoCreateResult.Id);
            Assert.Equal(entity.Cep, cepDtoCreateResult.Cep);
            Assert.Equal(entity.Logradouro, cepDtoCreateResult.Logradouro);
            Assert.Equal(entity.Numero, cepDtoCreateResult.Numero);
            Assert.Equal(entity.CreateAt, cepDtoCreateResult.CreateAt);

            //entity => DTOUpdateResult
            var cepDtoUpdateResult = Mapper.Map<CepDtoUpdateResult>(entity);
            Assert.Equal(entity.Id, cepDtoUpdateResult.Id);
            Assert.Equal(entity.Cep, cepDtoUpdateResult.Cep);
            Assert.Equal(entity.Logradouro, cepDtoUpdateResult.Logradouro);
            Assert.Equal(entity.Numero, cepDtoUpdateResult.Numero);
            Assert.Equal(entity.MunicipioId, cepDtoUpdateResult.MunicipioID);
            Assert.Equal(entity.UpdateAt, cepDtoUpdateResult.UpdateAt);

            //DTO => MODEL
            var cepModel = Mapper.Map<CepModel>(cepDto);
            Assert.Equal(cepDto.Id, cepModel.ID);
            Assert.Equal(cepDto.Cep, cepModel.Cep);
            Assert.Equal(cepDto.Logradouro, cepModel.Logradouro);
            Assert.Equal(cepDto.Numero, cepModel.Numero);
            Assert.Equal(cepDto.MunicipioId, cepModel.MunicipioID);

            var cepDtoCreate = Mapper.Map<CepDtoCreate>(cepModel);
            Assert.Equal(cepModel.Cep, cepDtoCreate.Cep);
            Assert.Equal(cepModel.Logradouro, cepDtoCreate.Logradouro);
            Assert.Equal(cepModel.Numero, cepDtoCreate.Numero);
            Assert.Equal(cepModel.MunicipioID, cepDtoCreate.MunicipioID);

            var cepDtoUpdate = Mapper.Map<CepDtoUpdate>(cepModel);
            Assert.Equal(cepModel.Cep, cepDtoCreate.Cep);
            Assert.Equal(cepModel.Logradouro, cepDtoCreate.Logradouro);
            Assert.Equal(cepModel.Numero, cepDtoCreate.Numero);
            Assert.Equal(cepModel.MunicipioID, cepDtoCreate.MunicipioID);
        }

    }
}
