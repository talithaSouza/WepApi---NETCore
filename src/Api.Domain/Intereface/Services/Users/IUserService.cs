using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Domain.Intereface.Services.Users
{
    public interface IUserService
    {
        Task<UserEntity> Get(Guid id);
        Task<IEnumerable<UserEntity>> GetAll(Guid id);
        Task<UserEntity> Post(UserEntity user);
        Task<UserEntity> Put(UserEntity user);
        Task<bool> Delete(Guid id);
    }
}
