using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Intereface.Services.Users;
using Api.Domain.Repository;

namespace Api.Service.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository _repository;
        public LoginService(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<object> FindByLogin(LoginDTO user)
        {
            if (user != null && !string.IsNullOrWhiteSpace(user.Email))
            {
                return await _repository.FindByLogin(user.Email);
            }

            return null;
        }
    }
}
