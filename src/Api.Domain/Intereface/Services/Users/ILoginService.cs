using System.Threading.Tasks;
using Api.Domain.Dtos;

namespace Api.Domain.Intereface.Services.Users
{
    public interface ILoginService
    {
        Task<object> FindByLogin(LoginDTO User);
    }
}
