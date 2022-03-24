using System;
using Api.Data.Mapping;
using Api.Domain.Entities;
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
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "administrador",
                    Email = "admin@email.com",
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                }
            );
        }
    }
}
