using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface IGenericRepository<TKey, TCreate, TRead, TUpdate>
    {
        Task<TRead> CreateAsync(TCreate entity);
        Task<TRead> GetByIdAsync(TKey id);
        Task<IEnumerable<TRead>> GetAllAsync(int? limit = 0);
        Task<bool> ExistsByIdAsync(TKey key);
        Task UpdateAsync(TKey id, TUpdate updateDTO);
        Task DeleteAsync(TKey id);
    }
}
