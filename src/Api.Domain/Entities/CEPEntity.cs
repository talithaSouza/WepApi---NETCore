using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class CEPEntity : BaseEntities
    {
        [Required]
        [MaxLength(100)]
        public string Cep { get; set; }

        [Required]
        [MaxLength(60)]
        public int Logradouro { get; set; }

        [MaxLength(10)]
        public string Numero { get; set; }

        [Required]
        public Guid MunicipioId { get; set; }
        public MunicipioEntity Municipio { get; set; }
    }
}
