using Shared.DTO.Users;
using Shared.Interfaces;
using Shared.Models;

namespace AuthService.Interfaces.Users
{
    public interface IUserRepository : IGenericRepository<Guid, User>
    {
    }
}
