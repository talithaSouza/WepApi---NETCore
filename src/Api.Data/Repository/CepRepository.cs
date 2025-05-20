using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class CepRepository : BaseRepository<CEPEntity>, ICepRepository
    {
        private DbSet<CEPEntity> _dataSet;

        public CepRepository(MyContext context) : base(context)
        {
            _dataSet = context.Set<CEPEntity>();
        }

        public async Task<CEPEntity> SelectAsync(string Cep)
        {
            try
            {
                return await _dataSet
                            .Include(x => x.Municipio)
                            .ThenInclude(x => x.Uf)
                            .FirstOrDefaultAsync(x => x.Cep == Cep);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
