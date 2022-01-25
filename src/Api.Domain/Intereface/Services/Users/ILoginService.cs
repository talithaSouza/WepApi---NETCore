using System.Threading.Tasks;

namespace Api.Domain.Intereface.Services.Users
{
    public interface ILoginService
    {
        Task<object> FindByLogin(UserEntity User);
    }
}
