using System;
using System.Collections.Generic;
using Api.Domain.Dtos.User;

namespace Api.Service.Test.Usuario
{
    public class UsuarioTest
    {
        public static string NomeUsuario { get; set; }
        public static string EmailUsuario { get; set; }
        public static string NomeUsuarioAlterado { get; set; }
        public static string EmailUsuarioAlterado { get; set; }
        public static Guid IdUsuario { get; set; }

        public List<UserDto> ListaUserDto { get; set; } = new List<UserDto>();
        public UserDto UserDto { get; set; }
        public UserDtoCreate UserDtoCreate { get; set; }
        public UserDtoCreateResult UserDtoCreateResult { get; set; }
        public UserDtoUpdate UserDtoUpdate { get; set; }
        public UserDtoUpdateResult UserDtoUpdateResult { get; set; }

        public UsuarioTest()
        {
            IdUsuario = Guid.NewGuid();
            NomeUsuario = Faker.Name.FullName();
            EmailUsuario = Faker.Internet.Email();
            NomeUsuarioAlterado = Faker.Name.FullName();
            EmailUsuario = Faker.Internet.Email();

            for (int i = 0; i < 10; i++)
            {
                var dto = new UserDto()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email()
                };

                ListaUserDto.Add(dto);
            }

            UserDto = new UserDto()
            {
                Id = IdUsuario,
                Name = NomeUsuario,
                Email = EmailUsuario,
            };

            UserDtoCreate = new UserDtoCreate()
            {
                Name = NomeUsuario,
                Email = EmailUsuario,
            };

            UserDtoCreateResult = new UserDtoCreateResult()
            {
                Id = IdUsuario,
                Name = NomeUsuario,
                Email = EmailUsuario,
                CreatAt = DateTime.UtcNow
            };

            UserDtoUpdate = new UserDtoUpdate()
            {
                Id = IdUsuario,
                Name = NomeUsuarioAlterado,
                Email = EmailUsuarioAlterado,
            };

            UserDtoUpdateResult = new UserDtoUpdateResult()
            {
                Id = IdUsuario,
                Name = NomeUsuarioAlterado,
                Email = EmailUsuarioAlterado,
                UpdatAt = DateTime.UtcNow
            };


        }
    }
}
