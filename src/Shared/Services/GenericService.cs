using Shared.Interfaces;

namespace Shared.Services
{
    public class GenericService<TRepository, TKey, TCreate, TRead, TUpdate>(TRepository repository)
        : IGenericService<TKey, TCreate, TRead, TUpdate>
        where TRepository : IGenericRepository<TKey, TCreate, TRead, TUpdate>
    {
        public virtual async Task<TRead> CreateAsync(TCreate createDTO) => 
            await repository.CreateAsync(createDTO);

        public virtual async Task<TRead> GetByIdAsync(TKey key) =>
            await repository.GetByIdAsync(key);

        public async Task<IEnumerable<TRead>> GetAllAsync(int? limit = 0) =>
            await repository.GetAllAsync(limit);

        public async Task<bool> ExistsByIdAsync(TKey key) =>
            await repository.ExistsByIdAsync(key);

        public virtual async Task UpdateAsync(TKey key, TUpdate updateDTO) =>
            await repository.UpdateAsync(key, updateDTO);

        public virtual async Task DeleteAsync(TKey key) =>
            await repository.DeleteAsync(key);
    }
}