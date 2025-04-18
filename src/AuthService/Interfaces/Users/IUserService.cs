using Shared.DTO.Users;
using Shared.Interfaces;
using Shared.Models;

namespace AuthService.Interfaces.Users
{
    public interface IUserService : IGenericService<Guid, User, UserCreateDTO, UserDTO, UserUpdateDTO>
    {
        Task<string?> LoginAsync(UserLoginDTO credentials);
    }
}
