using Api.Domain.Intereface;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    //AQUI ONDE AS CLASSES ENTRARAM PARA O BANCO DE DADOS COMO TABELAS
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
