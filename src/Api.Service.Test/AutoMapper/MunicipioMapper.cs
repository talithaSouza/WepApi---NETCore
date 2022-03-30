using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class MunicipioMapper : BaseTesteService
    {

        [Fact(DisplayName = "É Possivel Mapear os Modelos")]
        public void Teste_Mapper_Modelos_Municipio()
        {
            var model = new MunicipioModel()
            {
                ID = Guid.NewGuid(),
                Nome = Faker.Address.City(),
                CodIBGE = Faker.RandomNumber.Next(100000, 999999),
                UFID = Guid.NewGuid(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
            };

            var listaEntity = new List<MunicipioEntity>();
            for (int i = 0; i <= 5; i++)
            {
                listaEntity.Add(new MunicipioEntity()
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
                });

            }

            //MODEL => ENTITY
            var entity = Mapper.Map<MunicipioEntity>(model);
            Assert.Equal(model.ID, entity.Id);
            Assert.Equal(model.Nome, entity.Nome);
            Assert.Equal(model.CodIBGE, entity.CodIBGE);
            Assert.Equal(model.UFID, entity.UfID);
            Assert.Equal(model.CreateAt, entity.CreateAt);
            Assert.Equal(model.UpdateAt, entity.UpdateAt);

            //ENTITY => DTO
            var municipioDto = Mapper.Map<MunicipioDto>(entity);
            Assert.True(entity.Id == municipioDto.Id);
            Assert.Equal(entity.Nome, municipioDto.Nome);
            Assert.Equal(entity.CodIBGE, municipioDto.CodIBGE);
            Assert.Equal(entity.UfID, municipioDto.UfID);

            var listDto = Mapper.Map<List<MunicipioDto>>(listaEntity);
            Assert.True(listDto.Count() == listaEntity.Count());

            for (int i = 0; i < listDto.Count(); i++)
            {
                Assert.Equal(listDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listDto[i].Nome, listaEntity[i].Nome);
                Assert.Equal(listDto[i].CodIBGE, listaEntity[i].CodIBGE);
                Assert.Equal(listDto[i].UfID, listaEntity[i].UfID);
            }

            //ENTITY => DTOCompleto
            var municipioDtoCompleto = Mapper.Map<MunicipioDtoCompleto>(listaEntity.FirstOrDefault());
            Assert.True(listaEntity.FirstOrDefault().Id == municipioDtoCompleto.Id);
            Assert.Equal(listaEntity.FirstOrDefault().Nome, municipioDtoCompleto.Nome);
            Assert.Equal(listaEntity.FirstOrDefault().CodIBGE, municipioDtoCompleto.CodIBGE);
            Assert.Equal(listaEntity.FirstOrDefault().UfID, municipioDtoCompleto.UfID);
            Assert.NotNull(municipioDtoCompleto.Uf);

            //entity =>DTOCreateResult
            var municipioDtoCreateResult = Mapper.Map<MunicipioDtoCreateResult>(entity);
            Assert.Equal(entity.Id, municipioDtoCreateResult.Id);
            Assert.Equal(entity.Nome, municipioDtoCreateResult.Nome);
            Assert.Equal(entity.CodIBGE, municipioDtoCreateResult.CodIBGE);
            Assert.Equal(entity.UfID, municipioDtoCreateResult.UfID);
            Assert.Equal(entity.CreateAt, municipioDtoCreateResult.CreateAt);

            //entity => DTOUpdateResult
            var municipioDtoUpdateResult = Mapper.Map<MunicipioDtoUpdateResult>(entity);
            Assert.Equal(entity.Id, municipioDtoUpdateResult.Id);
            Assert.Equal(entity.Nome, municipioDtoUpdateResult.Nome);
            Assert.Equal(entity.CodIBGE, municipioDtoUpdateResult.CodIBGE);
            Assert.Equal(entity.UfID, municipioDtoUpdateResult.UfID);
            Assert.Equal(entity.UpdateAt, municipioDtoUpdateResult.UpdateAt);

            //DTO => MODEL
            var municipioModel = Mapper.Map<MunicipioModel>(municipioDto);
            Assert.Equal(municipioDto.Id, municipioModel.ID);
            Assert.Equal(municipioDto.Nome, municipioModel.Nome);
            Assert.Equal(municipioDto.CodIBGE, municipioModel.CodIBGE);
            Assert.Equal(municipioDto.UfID, municipioModel.UFID);

            var municipioDtoCreate = Mapper.Map<MunicipioDtoCreate>(municipioModel);
            Assert.Equal(municipioDtoCreate.Nome, municipioDtoCreate.Nome);
            Assert.Equal(municipioDtoCreate.CodIBGE, municipioDtoCreate.CodIBGE);
            Assert.Equal(municipioDtoCreate.UfID, municipioDtoCreate.UfID);

            var municipioDtoUpdate = Mapper.Map<MunicipioDtoUpdate>(municipioModel);
            Assert.Equal(municipioDtoUpdate.Id, municipioModel.ID);
            Assert.Equal(municipioDtoUpdate.Nome, municipioModel.Nome);
            Assert.Equal(municipioDtoUpdate.CodIBGE, municipioModel.CodIBGE);
            Assert.Equal(municipioDtoUpdate.UfID, municipioModel.UFID);

        }
    }
}
