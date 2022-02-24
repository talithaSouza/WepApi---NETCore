using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        //Usado para criar migrações
        public MyContext CreateDbContext(string[] args)
        {

            //var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=090112";
            //optionsBuilder.UseMySql(connectionString);
            var connectionString = "Server=localhost;Initial Catalog=dbAPI;MultipleActiveResultSets=true;User ID=sa;Pwd=090112";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseSqlServer(connectionString);


            return new MyContext(optionsBuilder.Options);
        }
    }
}
