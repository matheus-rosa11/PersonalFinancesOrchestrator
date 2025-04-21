using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface IGenericService<TKey, TEntity, TCreate, TRead, TUpdate>
    {
        Task<TRead> CreateAsync(TCreate createDTO);
        Task<TRead?> GetAsync(TKey key);
        Task<IEnumerable<TRead>> BatchGetAsync(int? limit = 0);
        Task<bool> ExistsByIdAsync(TKey key);
        Task UpdateAsync(TKey key, TUpdate updateDTO);
        Task DeleteAsync(TKey key);
    }
}
