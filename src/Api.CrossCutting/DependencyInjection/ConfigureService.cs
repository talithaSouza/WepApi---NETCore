using Api.Domain.Intereface.Services.Cep;
using Api.Domain.Intereface.Services.Municipio;
using Api.Domain.Intereface.Services.Uf;
using Api.Domain.Intereface.Services.Users;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependencieService(IServiceCollection serviceCollection)
        {
            #region Usuario
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();
            #endregion

            #region Uf
            serviceCollection.AddTransient<IUfService, UfService>();
            #endregion

            #region Municipio
            serviceCollection.AddTransient<IMunicipioservice, MunicipioService>();
            #endregion

            #region Cep
            serviceCollection.AddTransient<ICepService, CepService>();
            #endregion
        }

    }
}
