using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Municipio
{
    public class MunicipioDtoUpdate
    {
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome de Município é obrigatório")]
        [StringLength(60, ErrorMessage = "Nome de Município deve ter no maximo {1} caracteres")]
        public string Nome { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Código do IBGE Inválido")]
        public int CodIBGE { get; set; }

        [Required]
        public Guid UfID { get; set; }
    }
}
