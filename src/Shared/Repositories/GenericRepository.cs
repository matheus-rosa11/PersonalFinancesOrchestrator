using Shared.Interfaces;

namespace Shared.Repositories
{
    public class GenericRepository<TKey, TCreate, TRead, TUpdate> : IGenericRepository<TKey, TCreate, TRead, TUpdate>
    {
        public Task<TRead> CreateAsync(TCreate entity)
        {
            throw new NotImplementedException();
        }

        public Task<TRead> GetByIdAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TRead>> GetAllAsync(int? limit = 0)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsByIdAsync(TKey key)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TKey id, TUpdate updateDTO)
        {
            throw new NotImplementedException();
        }
        public Task DeleteAsync(TKey id)
        {
            throw new NotImplementedException();
        }
    }
}
