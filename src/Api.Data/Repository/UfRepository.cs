using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class UfRepository : BaseRepository<UfEntity>, IUfRepository
    {
        private DbSet<UfEntity> _dataSet;

        public UfRepository(MyContext context) : base(context)
        {
            _dataSet = context.Set<UfEntity>();
        }
    }
}
