﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Application.Dtos;

namespace UA.Application.Interfaces
{
    public  interface IUserService
    {
        Task<UserDto?> GetUserByIdAsync(Guid id);
        Task<UserDto?> CreateUserAsync(UserCreateUpdateDto dto);
        Task<UserDto?> UpdateUserAsync(Guid id, UserCreateUpdateDto dto);
        Task<bool> DeleteUserAsync(Guid id);
        Task<UserDto?> UpdateUserEmail(Guid id, UserEmailUpdateDto email);
        Task<List<UserDto>> GetUsersByEmails(string filter);
    }
}
