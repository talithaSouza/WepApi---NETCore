using System;
using System.Collections.Generic;
using Api.Domain.Dtos.Uf;
using Api.Domain.Entities;

namespace Api.Service.Test.Uf
{
    public class UfBaseTest
    {
        public Guid IdUf { get; set; }
        public string SiglaUf { get; set; }
        public string NomeUf { get; set; }
        // public IEnumerable<MunicipioEntity> ListMunicipios { get; set; } => propriedade de navegação

        public static UfDto ufDto { get; set; }
        public static List<UfDto> ListaUfDto { get; set; } = new List<UfDto>();

        public UfBaseTest()
        {
            IdUf = Guid.NewGuid();
            SiglaUf = Faker.Address.UsState().Substring(1, 3);
            NomeUf = Faker.Address.UsState();

            //para a lista
            for (int i = 0; i < 10; i++)
            {
                var dto = new UfDto()
                {
                    Id = IdUf,
                    Nome = Faker.Country.Name(),
                    Sigla = Faker.Country.Name().Substring(1, 3)
                };

                ListaUfDto.Add(dto);
            }
            //

            ufDto = new UfDto()
            {
                Id = IdUf,
                Nome = NomeUf,
                Sigla = SiglaUf
            };
        }
    }
}
