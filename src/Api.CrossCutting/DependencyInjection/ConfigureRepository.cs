using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Intereface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependencieRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            serviceCollection.AddDbContext<MyContext>(
            options => options.UseMySql("Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=090112")
        );
        }
    }
}
