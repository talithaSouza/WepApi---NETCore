using Api.Domain.Intereface.Services.Users;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependencieService(IServiceCollection serviceCollection)
            => serviceCollection.AddTransient<IUserService, UserService>();

    }
}
