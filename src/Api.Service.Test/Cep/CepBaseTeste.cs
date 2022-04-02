using System;
using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.Uf;

namespace Api.Service.Test.Cep
{
    public abstract class CepBaseTeste
    {
        public Guid IdCep { get; set; }
        public string Cep { get; set; }
        public string LogradouroCep { get; set; }
        public string NumeroCep { get; set; }
        public Guid MunicipioId { get; set; }

        public string CepAlterado { get; set; }
        public string LogradouroAlterado { get; set; }
        public string NumeroAlterado { get; set; }

        public CepDto CepDto { get; set; }
        public CepDtoCreate CepDtoCreate { get; set; }
        public CepDtoCreateResult CepDtoCreateResult { get; set; }
        public CepDtoUpdate CepDtoUpdate { get; set; }
        public CepDtoUpdateResult CepDtoUpdateResult { get; set; }

        public CepBaseTeste()
        {
            Cep = Faker.RandomNumber.Next(000000, 999999).ToString();
            LogradouroCep = Faker.Address.StreetAddress();
            NumeroCep = Faker.RandomNumber.Next().ToString();
            MunicipioId = new Guid("ea78590c-5276-4e6d-8840-83d984c3b40f");
            IdCep = Guid.NewGuid();

            CepAlterado = Faker.RandomNumber.Next(000000, 999999).ToString();
            LogradouroAlterado = Faker.Address.StreetAddress();
            NumeroAlterado = Faker.RandomNumber.Next().ToString();

            CepDto = new CepDto()
            {
                Id = IdCep,
                Cep = this.Cep,
                Logradouro = LogradouroCep,
                Numero = NumeroCep,
                MunicipioId = this.MunicipioId,
                Municipio = new MunicipioDtoCompleto
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(100000, 999999),
                    UfID = Guid.NewGuid(),
                    Uf = new UfDto
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Country.Name(),
                        Sigla = Faker.Country.Name().Substring(1, 3)
                    }
                }
            };

            CepDtoCreate = new CepDtoCreate()
            {
                Cep = Cep,
                Logradouro = LogradouroCep,
                Numero = NumeroCep,
                MunicipioID = MunicipioId
            };

            CepDtoCreateResult = new CepDtoCreateResult()
            {
                Id = IdCep,
                Cep = Cep,
                Logradouro = LogradouroCep,
                Numero = NumeroCep,
                MunicipioID = MunicipioId,
                CreateAt = DateTime.UtcNow,
            };

            CepDtoUpdate = new CepDtoUpdate()
            {
                Id = IdCep,
                Cep = Cep,
                Logradouro = LogradouroAlterado,
                Numero = NumeroAlterado,
                MunicipioID = MunicipioId,
            };

            CepDtoUpdateResult = new CepDtoUpdateResult()
            {
                Id = IdCep,
                Cep = CepAlterado,
                Logradouro = LogradouroAlterado,
                Numero = NumeroAlterado,
                MunicipioID = MunicipioId,
                UpdateAt = DateTime.UtcNow,
            };
        }
    }
}
