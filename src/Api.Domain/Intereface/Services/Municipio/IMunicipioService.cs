using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Municipio;

namespace Api.Domain.Intereface.Services.Municipio
{
    public interface IMunicipioservice
    {
        Task<MunicipioDto> Get(Guid id);
        Task<MunicipioDtoCompleto> GetCompleteById(Guid Id);
        Task<MunicipioDtoCompleto> GetCompleteByIBGE(int codIBGE);
        Task<IEnumerable<MunicipioDto>> GetAll();
        Task<MunicipioDtoCreateResult> Post(MunicipioDtoCreate municipio);
        Task<MunicipioDtoUpdateResult> Put(MunicipioDtoUpdate municipio);
        Task<bool> Delete(Guid id);
    }
}
