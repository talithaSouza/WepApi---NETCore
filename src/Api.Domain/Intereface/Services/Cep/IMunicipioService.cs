using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.Uf;

namespace Api.Domain.Intereface.Services.Cep
{
    public interface IMunicipioservice
    {
        Task<MunicipioDto> Get(Guid id);
        Task<CepDto> GetByCep(string cep);
        Task<IEnumerable<CepDto>> GetAll();
        Task<CepDtoCreateResult> Post(CepDtoCreate municipio);
        Task<CepDtoUpdateResult> Put(CepDtoUpdate municipio);
        Task<bool> Delete(Guid id);
    }
}
