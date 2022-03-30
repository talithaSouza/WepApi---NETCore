using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.Municipio;

namespace Api.Domain.Intereface.Services.Cep
{
    public interface ICepservice
    {
        Task<CepDto> Get(Guid id);
        Task<CepDto> GetByCep(string cep);
        Task<IEnumerable<CepDto>> GetAll();
        Task<CepDtoCreateResult> Post(CepDtoCreate cep);
        Task<CepDtoUpdateResult> Put(CepDtoUpdate cep);
        Task<bool> Delete(Guid id);
    }
}