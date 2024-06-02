using Core.Dtos;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDto>> GetAsync();
        Task<UserDto> GetByIdAsync(Guid id);
        Task<UserDto> PostAsync(UserDto user);
        Task<UserDto> PutAsync(Guid id, UserDto user);
        Task<User> DeleteAsync(Guid id);
    }
}
