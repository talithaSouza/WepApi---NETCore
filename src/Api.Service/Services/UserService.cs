using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Intereface;
using Api.Domain.Intereface.Services.Users;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _repository;

        //Injeção de dependencia
        public UserService(IRepository<UserEntity> repository)
        {
            _repository = repository;
        }
        //

        public async Task<bool> Delete(Guid id)
            => await _repository.DeleteAsync(id);

        public async Task<UserEntity> Get(Guid id)
            => await _repository.SelectAsync(id);

        public async Task<IEnumerable<UserEntity>> GetAll(Guid id)
            => await _repository.SelectAsync();

        public async Task<UserEntity> Post(UserEntity user)
            => await _repository.InsertAsync(user);

        public async Task<UserEntity> Put(UserEntity user)
            => await _repository.UpdateAsync(user);
    }
}
