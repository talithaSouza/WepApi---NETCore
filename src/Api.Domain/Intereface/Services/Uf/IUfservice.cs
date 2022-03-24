using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Uf;

namespace Api.Domain.Intereface.Services.Uf
{
    public interface IUfservice
    {
        Task<UfDto> Get(Guid id);
        Task<IEnumerable<UfDto>> GetAll();
    }
}
