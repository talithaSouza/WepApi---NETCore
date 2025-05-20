using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class MunicipioRepository : BaseRepository<MunicipioEntity>, IMunicipioRepository
    {
        private DbSet<MunicipioEntity> _dataSet;

        public MunicipioRepository(MyContext context) : base(context)
        {
            _dataSet = context.Set<MunicipioEntity>();
        }

        public async Task<MunicipioEntity> GetCompleteByIBGE(int codIBGE)
        {
            try
            {
                return await _dataSet
                            .Include(x => x.Uf)
                            .FirstOrDefaultAsync(x => x.CodIBGE == codIBGE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MunicipioEntity> GetCompleteById(Guid Id)
        {
            try
            {
                return await _dataSet
                            .Include(x => x.Uf)
                            .FirstOrDefaultAsync(x => x.Id == Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
