using Shared.DTO.Users;
using Shared.Interfaces;

namespace AuthService.Interfaces.Users
{
    public interface IUserRepository : IGenericRepository<Guid, UserCreateDTO, UserDTO, UserUpdateDTO>
    {
    }
}
