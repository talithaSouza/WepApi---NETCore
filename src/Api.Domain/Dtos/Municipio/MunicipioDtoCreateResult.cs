using System;

namespace Api.Domain.Dtos.Municipio
{
    public class MunicipioDtoCreateResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public int CodIBGE { get; set; }
        public Guid UfID { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
