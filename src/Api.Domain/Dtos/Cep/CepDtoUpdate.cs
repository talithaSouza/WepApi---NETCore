using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Cep
{
    public class CepDtoUpdate
    {
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome de Município é obrigatório")]
        [StringLength(60, ErrorMessage = "Nome de Município deve ter no maximo {1} caracteres")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Nome de Município é obrigatório")]
        public string Logradouro { get; set; }
        public string Numero { get; set; }

        [Required(ErrorMessage = "Município é obrigatório")]
        public Guid MunicipioID { get; set; }
    }
}
