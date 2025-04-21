using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;
using Shared.Utils.Helpers;

namespace Shared.Repositories
{
    public class GenericRepository<TKey, TEntity>(DbContext context) : IGenericRepository<TKey, TEntity>
        where TEntity : class
    {
        protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            var created = await _dbSet.AddAsync(entity);
            await context.SaveChangesAsync();
            return created.Entity;
        }

        public async Task<TEntity?> GetAsync(TKey id) => await _dbSet.FindAsync(id);

        public async Task<IEnumerable<TEntity>> BatchGetAsync(int? limit = 0)
        {
            var query = _dbSet.AsQueryable();

            if (limit is > 0)
                query = query.Take(limit.Value);

            return await query.ToListAsync();
        }

        public async Task<bool> ExistsByIdAsync(TKey id) => await _dbSet.FindAsync(id) is not null;

        public async Task UpdateAsync(TKey id, TEntity updatedEntity)
        {
            ArgumentNullException.ThrowIfNull(updatedEntity);

            var existing = await _dbSet.FindAsync(id)
                ?? throw new KeyNotFoundException(MessageHelper.EntityNotFound(id));

            context.Entry(existing).CurrentValues.SetValues(updatedEntity);

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TKey id)
        {
            var existing = await _dbSet.FindAsync(id) ??
                throw new KeyNotFoundException(MessageHelper.EntityNotFound(id));

            _dbSet.Remove(existing);

            await context.SaveChangesAsync();
        }
    }
}
