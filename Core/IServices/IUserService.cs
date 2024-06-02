using Core.Dtos;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAsync();
        Task<UserDto> GetByIdAsync(Guid id);
        Task<UserDto> PostAsync(UserDto user);
        Task<UserDto> PutAsync(Guid id, UserDto user);
        Task<User> DeleteAsync(Guid id);
    }
}
