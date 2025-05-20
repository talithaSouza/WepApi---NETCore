using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class UsuarioMapper : BaseTesteService
    {

        [Fact(DisplayName = "É Possivel Mapear os Modelos")]
        public void E_Possivel_Mapear_Os_Modelos()
        {
            var model = new UserModel()
            {
                ID = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
            };

            var listaEntity = new List<UserEntity>();
            for (int i = 0; i <= 5; i++)
            {
                listaEntity.Add(new UserEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                });

            }

            //MODEL => ENTITY
            var entity = Mapper.Map<UserEntity>(model);
            Assert.Equal(model.ID, entity.Id);
            Assert.Equal(model.Name, entity.Name);
            Assert.Equal(model.Email, entity.Email);
            Assert.Equal(model.CreateAt, entity.CreateAt);
            Assert.Equal(model.UpdateAt, entity.UpdateAt);

            //ENTITY => DTO
            var userDto = Mapper.Map<UserDto>(entity);
            Assert.Equal(entity.Id, userDto.Id);
            Assert.Equal(entity.Name, userDto.Name);
            Assert.Equal(entity.Email, userDto.Email);
            Assert.Equal(entity.CreateAt, userDto.CreateAt);

            var listDto = Mapper.Map<List<UserDto>>(listaEntity);
            Assert.True(listDto.Count() == listaEntity.Count());

            for (int i = 0; i < listDto.Count(); i++)
            {
                Assert.Equal(listDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listDto[i].Name, listaEntity[i].Name);
                Assert.Equal(listDto[i].Email, listaEntity[i].Email);
                Assert.Equal(listDto[i].CreateAt, listaEntity[i].CreateAt);
            }

            var userDtoCreateResult = Mapper.Map<UserDtoCreateResult>(entity);
            Assert.Equal(entity.Id, userDtoCreateResult.Id);
            Assert.Equal(entity.Name, userDtoCreateResult.Name);
            Assert.Equal(entity.Email, userDtoCreateResult.Email);
            Assert.Equal(entity.CreateAt, userDtoCreateResult.CreateAt);

            var userDtoUpdateResult = Mapper.Map<UserDtoUpdateResult>(entity);
            Assert.Equal(entity.Id, userDtoUpdateResult.Id);
            Assert.Equal(entity.Name, userDtoUpdateResult.Name);
            Assert.Equal(entity.Email, userDtoUpdateResult.Email);
            Assert.Equal(entity.UpdateAt, userDtoUpdateResult.UpdateAt);

            //DTO => MODEL
            var userModel = Mapper.Map<UserModel>(userDto);
            Assert.Equal(userDto.Id, userModel.ID);
            Assert.Equal(userDto.Name, userModel.Name);
            Assert.Equal(userDto.Email, userModel.Email);
            Assert.Equal(userDto.CreateAt, userModel.CreateAt);

            var userDtoCreate = Mapper.Map<UserDtoCreate>(userModel);
            Assert.Equal(userDtoCreate.Name, userDtoCreate.Name);
            Assert.Equal(userDtoCreate.Email, userDtoCreate.Email);

            var userDtoUpdate = Mapper.Map<UserDtoUpdate>(userModel);
            Assert.Equal(userDtoUpdate.Id, userModel.ID);
            Assert.Equal(userDtoUpdate.Name, userModel.Name);
            Assert.Equal(userDtoUpdate.Email, userModel.Email);
        }
    }
}
