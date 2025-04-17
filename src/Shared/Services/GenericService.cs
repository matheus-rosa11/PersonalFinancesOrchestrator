using AutoMapper;
using Shared.Interfaces;

namespace Shared.Services
{
    public class GenericService<TRepository, TKey, TEntity, TCreate, TRead, TUpdate>(TRepository repository, IMapper mapper)
        : IGenericService<TKey, TEntity, TCreate, TRead, TUpdate>
        where TRepository : IGenericRepository<TKey, TEntity>
    {
        public virtual async Task<TRead> CreateAsync(TCreate createDTO) => 
            mapper.Map<TRead>(await repository.CreateAsync(mapper.Map<TEntity>(createDTO)));

        public virtual async Task<TRead> GetByIdAsync(TKey key) =>
            mapper.Map<TRead>(await repository.GetByIdAsync(key));

        public async Task<IEnumerable<TRead>> GetAllAsync(int? limit = 0) =>
            mapper.Map<IEnumerable<TRead>>(await repository.GetAllAsync(limit));

        public async Task<bool> ExistsByIdAsync(TKey key) =>
            await repository.ExistsByIdAsync(key);

        public virtual async Task UpdateAsync(TKey key, TUpdate updateDTO) =>
            await repository.UpdateAsync(key, mapper.Map<TEntity>(updateDTO));

        public virtual async Task DeleteAsync(TKey key) =>
            await repository.DeleteAsync(key);
    }
}