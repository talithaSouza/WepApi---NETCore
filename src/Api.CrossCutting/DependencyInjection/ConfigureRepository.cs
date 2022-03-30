using System;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Intereface;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependencieRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            #region INJE.DEPEN REPOSITORIOS
            //USUARIO
            serviceCollection.AddScoped<IUserRepository, UserRepository>();

            //UF
            serviceCollection.AddScoped<IUfRepository, UfRepository>();

            //MUNICIPIO
            serviceCollection.AddScoped<IMunicipioRepository, MunicipioRepository>();

            //CEP
            serviceCollection.AddScoped<ICepRepository, CepRepository>();
            #endregion

            if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "SQLSERVER".ToLower())
            {
                serviceCollection.AddDbContext<MyContext>(
                  options => options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION"))
                );
            }
            //CASO MYSQL
            else
            {
                serviceCollection.AddDbContext<MyContext>(
                  options => options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION"))
                );
            }
        }
    }
}
