using Core.Dtos;
using Core.Entities;
using Core.IRepositories;
using Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<IEnumerable<UserDto>> GetAsync()
        {
            return _userRepository.GetAsync();
        }

        public Task<UserDto> GetByIdAsync(Guid id)
        {
            return _userRepository.GetByIdAsync(id);
        }

        public Task<UserDto> PostAsync(UserDto user)
        {
            return _userRepository.PostAsync(user);
        }

        public Task<UserDto> PutAsync(Guid id, UserDto user)
        {
            return _userRepository.PutAsync(id, user);
        }
        public Task<User> DeleteAsync(Guid id)
        {
            return _userRepository.DeleteAsync(id);
        }
    }
}
