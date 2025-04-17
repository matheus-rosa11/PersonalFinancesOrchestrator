using AuthService.Interfaces.Users;
using Shared.Database;
using Shared.Models;
using Shared.Repositories;

namespace AuthService.Repositories
{
    public class UserRepository(AppDbContext context) 
        : GenericRepository<Guid, User>(context),
        IUserRepository
    {
    }
}
