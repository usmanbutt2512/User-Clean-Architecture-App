using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Application.Interfaces;
using UA.Domain.Entities;
using UA.Infrastructure.Data;

namespace UA.Infrastructure.Repository
{
    public class UserRepository : IRepository<User>
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> AddAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task RemoveAsync(User entity)
        {
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
        }   

        public async Task<User> UpdateAsync(User entity)
        {
            var User = _context.Users.Update(entity).Entity;
            await _context.SaveChangesAsync();
            return User;
        }
    }
}
