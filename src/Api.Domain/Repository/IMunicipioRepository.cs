using System;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Intereface;

namespace Api.Domain.Repository
{
    public interface IMunicipioRepository : IRepository<MunicipioEntity>
    {
        Task<MunicipioEntity> GetCompleteById(Guid Id);
        Task<MunicipioEntity> GetCompleteByIBGE(int codIBGE);
    }
}
