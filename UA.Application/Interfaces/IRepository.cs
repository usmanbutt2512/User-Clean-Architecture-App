using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Domain.Entities;

namespace UA.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync(); //not a Requirment in assignment but still added
        Task<T?> GetByIdAsync(Guid id);
        Task<T> UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task<IEnumerable<T>> GetByFilters(string filter);
    }
}
