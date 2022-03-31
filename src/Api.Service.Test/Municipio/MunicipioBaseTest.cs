using System;
using System.Collections.Generic;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.Uf;
using Api.Domain.Entities;

namespace Api.Service.Test.Municipio
{
    public class MunicipioBaseTest
    {
        public static Guid IdMunicipio { get; set; }
        public static string NomeMunicipio { get; set; }
        public static int CodIBGEMunicipio { get; set; }
        public static Guid UfIDMunicipio { get; set; }

        public static string NomeMunicipioAlterado { get; set; }
        public static int CodIBGEMunicipioAlterado { get; set; }
        public static Guid UfIDMunicipioAlterado { get; set; }

        //DTOs
        public List<MunicipioDto> ListMunicipioDto { get; set; } = new List<MunicipioDto>();
        public MunicipioDto MunicipioDto { get; set; }
        public MunicipioDtoCompleto MunicipioDtoCompleto { get; set; }
        public MunicipioDtoCreate MunicipioDtoCreate { get; set; }
        public MunicipioDtoCreateResult MunicipioDtoCreateResult { get; set; }
        public MunicipioDtoUpdate MunicipioDtoUpdate { get; set; }
        public MunicipioDtoUpdateResult MunicipioDtoUpdateResult { get; set; }


        public MunicipioBaseTest()
        {
            IdMunicipio = Guid.NewGuid();
            NomeMunicipio = Faker.Address.City();
            CodIBGEMunicipio = Faker.RandomNumber.Next(100000, 999999);
            UfIDMunicipio = Guid.NewGuid();
            // P/Update
            NomeMunicipioAlterado = Faker.Address.City();
            CodIBGEMunicipioAlterado = Faker.RandomNumber.Next(100000, 999999);
            UfIDMunicipioAlterado = Guid.NewGuid();

            //DTOS
            for (int i = 0; i < 10; i++)
            {
                var dto = new MunicipioDto()
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(100000, 999999),
                    UfID = Guid.NewGuid()
                };

                ListMunicipioDto.Add(dto);
            }

            MunicipioDto = new MunicipioDto()
            {
                Id = IdMunicipio,
                Nome = NomeMunicipio,
                CodIBGE = CodIBGEMunicipio,
                UfID = UfIDMunicipio
            };

            MunicipioDtoCompleto = new MunicipioDtoCompleto()
            {
                Id = IdMunicipio,
                Nome = NomeMunicipio,
                CodIBGE = CodIBGEMunicipio,
                UfID = UfIDMunicipio,
                Uf = new UfDto
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Country.Name(),
                    Sigla = Faker.Country.Name().Substring(1, 3)
                }
            };

            MunicipioDtoCreate = new MunicipioDtoCreate()
            {
                Nome = NomeMunicipio,
                CodIBGE = CodIBGEMunicipio,
                UfID = UfIDMunicipio
            };

            MunicipioDtoCreateResult = new MunicipioDtoCreateResult()
            {
                Id = IdMunicipio,
                Nome = NomeMunicipio,
                CodIBGE = CodIBGEMunicipio,
                UfID = UfIDMunicipio,
                CreateAt = DateTime.UtcNow
            };

            MunicipioDtoUpdate = new MunicipioDtoUpdate()
            {
                Id = IdMunicipio,
                Nome = NomeMunicipioAlterado,
                CodIBGE = CodIBGEMunicipioAlterado,
                UfID = UfIDMunicipioAlterado,
            };

            MunicipioDtoUpdateResult = new MunicipioDtoUpdateResult()
            {
                Id = IdMunicipio,
                Nome = NomeMunicipioAlterado,
                CodIBGE = CodIBGEMunicipioAlterado,
                UfID = UfIDMunicipioAlterado,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}

