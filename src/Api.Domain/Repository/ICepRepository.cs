using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Intereface;

namespace Api.Domain.Repository
{
    public interface ICepRepository : IRepository<CEPEntity>
    {
        Task<CEPEntity> SelectAsync(string Cep);
    }
}
