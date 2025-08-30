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

        public Task<UserDto> CreateUserAsync(UserCreateUpdateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto?> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user != null)
            {
                return new UserDto
                (
                    user.Id,
                    user.Name,
                    user.Email,
                    user.CreatedAt
                );              
            }
            return null;
        }

        public Task<UserDto> UpdateUserAsync(UserCreateUpdateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> UpdateUserEmail(Guid id, UserEmailUpdateDto email)
        {
            throw new NotImplementedException();
        }
    }
}
