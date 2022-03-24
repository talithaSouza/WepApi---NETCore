using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class MunicipioEntity : BaseEntities
    {
        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }
        public int CodIBGE { get; set; }
        [Required]
        public Guid UfID { get; set; }
        public UfEntity Uf { get; set; }
        public IEnumerable<CEPEntity> ListCeps { get; set; }
    }
}
