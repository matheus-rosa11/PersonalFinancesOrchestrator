using AuthService.Interfaces.Users;
using Microsoft.EntityFrameworkCore;
using Shared.Database;
using Shared.Models;
using Shared.Repositories;

namespace AuthService.Repositories
{
    public class UserRepository(AppDbContext context)
        : GenericRepository<Guid, User>(context),
        IUserRepository
    {
        public async Task<User?> GetByEmailAsync(string email) => await _dbSet.FirstOrDefaultAsync(x => x.Email == email);
    }
}
