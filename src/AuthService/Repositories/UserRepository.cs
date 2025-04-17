using AuthService.Interfaces.Users;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shared.Database;
using Shared.Models;

namespace AuthService.Repositories
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        public async Task<User> CreateAsync(User entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            var createdUser = await context.AddAsync(entity);

            await context.SaveChangesAsync();

            return createdUser.Entity;
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsByIdAsync(Guid key)
        {
            return await context.Users.AnyAsync(x => x.Id == key);
        }

        public Task<IEnumerable<User>> GetAllAsync(int? limit = 0)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, User updatedEntity)
        {
            throw new NotImplementedException();
        }
    }
}
