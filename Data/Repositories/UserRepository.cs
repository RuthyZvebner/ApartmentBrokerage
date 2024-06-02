using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.IRepositories;
using Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAsync()
        {
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(_context.Users);
            return await Task.FromResult(usersDto);
        }

        public async Task<UserDto> GetByIdAsync(Guid id)
        {
            var userDto = _mapper.Map<UserDto>(_context.Users.Where(x => x.Id == id).First());
            return await Task.FromResult(userDto);
        }

        public async Task<UserDto> PostAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            userDto.Id = user.Id;
            return userDto;
        }

        public async Task<UserDto> PutAsync(Guid id, UserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            User userToUpdate = await _context.Users.FindAsync(id);
            if (userToUpdate == null)
                return null;
            userToUpdate.Email = userDto.Email;
            userToUpdate.Id = userDto.Id;
            userToUpdate.UserName = userDto.UserName;
            userToUpdate.Password = userDto.Password;
            userToUpdate.Phone = userDto.Phone;
            UserRole role;
            if(Enum.TryParse<UserRole>(userDto.Role, out role))
                userToUpdate.Role = role;
            else 
                userToUpdate.Role=UserRole.Tenant;

            await _context.SaveChangesAsync();
            return _mapper.Map<UserDto>(userToUpdate);
        }

        public async Task<User> DeleteAsync(Guid id)
        {
            User userToDelete = _context.Users.Where(x => x.Id == id).First();
            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                await _context.SaveChangesAsync();
                return userToDelete;
            }
            return null;
        }
    }
}
