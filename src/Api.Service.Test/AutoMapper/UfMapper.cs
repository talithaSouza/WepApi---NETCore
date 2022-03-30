using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.Uf;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class UfMapper : BaseTesteService
    {
        [Fact(DisplayName = "É Possivel Mapear os Modelos de UF")]
        public void Teste_Mapper_Modelos_Uf()
        {
            var model = new UfModel()
            {
                ID = Guid.NewGuid(),
                Nome = Faker.Address.UsState(),
                Sigla = Faker.Address.UsState().Substring(1, 3),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
            };

            var listaEntity = new List<UfEntity>();
            for (int i = 0; i <= 5; i++)
            {
                listaEntity.Add(new UfEntity()
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.UsState(),
                    Sigla = Faker.Address.UsState().Substring(1, 3),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                });

            }

            //MODEL => ENTITY
            var entity = Mapper.Map<UfEntity>(model);
            Assert.Equal(model.ID, entity.Id);
            Assert.Equal(model.Nome, entity.Nome);
            Assert.Equal(model.Sigla, entity.Sigla);
            Assert.Equal(model.CreateAt, entity.CreateAt);
            Assert.Equal(model.UpdateAt, entity.UpdateAt);

            //ENTITY => DTO
            var ufDto = Mapper.Map<UfDto>(entity);
            Assert.Equal(entity.Id, ufDto.Id);
            Assert.Equal(entity.Nome, ufDto.Nome);
            Assert.Equal(entity.Sigla, ufDto.Sigla);

            var listUfDto = Mapper.Map<List<UfDto>>(listaEntity);
            Assert.True(listUfDto.Count() == listaEntity.Count());

            for (int i = 0; i < listUfDto.Count(); i++)
            {
                Assert.Equal(listUfDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listUfDto[i].Nome, listaEntity[i].Nome);
                Assert.Equal(listUfDto[i].Sigla, listaEntity[i].Sigla);
            }

            //DTO => MODEL
            var ufModel = Mapper.Map<UfModel>(ufDto);
            Assert.Equal(ufDto.Id, ufModel.ID);
            Assert.Equal(ufDto.Nome, ufModel.Nome);
            Assert.Equal(ufDto.Sigla, ufModel.Sigla);
        }

    }
}
