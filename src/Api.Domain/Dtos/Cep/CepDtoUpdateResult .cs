using System;

namespace Api.Domain.Dtos.Cep
{
    public class CepDtoUpdateResult
    {
        public Guid Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public Guid MunicipioID { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
