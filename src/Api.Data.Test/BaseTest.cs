using System;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Test
{
    public abstract class BaseTest
    {
        public BaseTest()
        {

        }


    }
    //RESPONSÁVEL POR CRIAR O NOME DO BANCO DE DADOS E CRIAR O CONTEXTO PARA TESTE
    public class DbTest : IDisposable
    {
        public string dataBaseName { get; set; } = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        public ServiceProvider ServiceProvider { get; private set; }

        public DbTest()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<MyContext>(p =>
                p.UseSqlServer($"Persist Security Info=True; Server=localhost;Initial Catalog={dataBaseName};MultipleActiveResultSets=true;User ID=sa;Pwd=090112"),
                  ServiceLifetime.Transient
            );

            ServiceProvider = serviceCollection.BuildServiceProvider();
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureCreated();
            }

        }


        //DELETA O BANCO DE DADOS AO FINAL DO TESTE
        public void Dispose()
        {
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}
