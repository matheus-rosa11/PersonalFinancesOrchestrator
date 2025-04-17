using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface IGenericRepository<TKey, TEntity>
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(TKey id);
        Task<IEnumerable<TEntity>> GetAllAsync(int? limit = 0);
        Task<bool> ExistsByIdAsync(TKey key);
        Task UpdateAsync(TKey id, TEntity updatedEntity);
        Task DeleteAsync(TKey id);
    }
}
