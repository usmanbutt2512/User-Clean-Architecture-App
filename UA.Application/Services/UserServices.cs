using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Application.Dtos;
using UA.Application.Interfaces;
using UA.Domain.Entities;

namespace UA.Application.Services
{
    public class UserServices : IUserService
    {
        private IRepository<User> _userRepo;
        public UserServices(IRepository<User> userRepository)
        {
            _userRepo = userRepository;
        }

        public async Task<UserDto?> CreateUserAsync(UserCreateUpdateDto dto)
        {            
            var user = await _userRepo.AddAsync(new User
            {
                Name = dto.Name,
                Email = dto.Email
            });

            if (user != null)
            {                
                return Map(user);
            }
            return null;
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user != null)
            {
                await _userRepo.RemoveAsync(user);
                return true;
            }
            return false;
        }

        public async Task<UserDto?> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user != null)
            {
                return Map(user);         
            }
            return null;
        }

        public async Task<UserDto?> UpdateUserAsync(Guid id, UserCreateUpdateDto dto)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user != null)
            {
                user.Name = dto.Name;
                user.Email = dto.Email;
                var updatedUser = await _userRepo.UpdateAsync(user);
                return Map(updatedUser);
            }
            return null;
        }

        public async Task<UserDto?> UpdateUserEmail(Guid id, UserEmailUpdateDto email)
        {

            var user = await _userRepo.GetByIdAsync(id);
            if (user != null) 
            { 
                user.Email = email.Email;
                var updatedUser = await _userRepo.UpdateAsync(user);
                return Map(updatedUser);
            }
            return null;
        }

        private static UserDto Map(User u) => new UserDto(u.Id, u.Name, u.Email, u.CreatedAt);
    }
}
