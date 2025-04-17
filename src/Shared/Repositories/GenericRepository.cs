using Shared.Interfaces;

namespace Shared.Repositories
{
    public class GenericRepository<TKey, TEntity> : IGenericRepository<TKey, TEntity>
    {
        public Task<TEntity> CreateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsByIdAsync(TKey key)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync(int? limit = 0)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TKey id, TEntity updatedEntity)
        {
            throw new NotImplementedException();
        }
    }
}
