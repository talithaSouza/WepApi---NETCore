using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Seeds
{
    public static class MunicipioSeeds
    {
        public static void MunicipioBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MunicipioEntity>().HasData(
                new MunicipioEntity()
                {
                    Id = new Guid("ea78590c-5276-4e6d-8840-83d984c3b40f"),
                    Nome = "Sobral",
                    CodIBGE = 1295438038,
                    UfID = new Guid("5FF1B59E-11E7-414D-827E-609DC5F7E333"),
                }
            );
        }
    }
}
