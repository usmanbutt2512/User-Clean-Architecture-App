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
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task Remove(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User> UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
