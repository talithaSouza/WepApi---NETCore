using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        //Usado para criar migrações
        public MyContext CreateDbContext(string[] args)
        {

            var connectionString = "Server=localhost;Port=3303;Database=api_dotnet;User=root;Password=Abc12345!;";
            // var connectionString = "Server=sqlserver_container;Initial Catalog=dbAPI;MultipleActiveResultSets=true;User ID=sa;Pwd=Abc12345!";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            // optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));


            return new MyContext(optionsBuilder.Options);
        }
    }
}
