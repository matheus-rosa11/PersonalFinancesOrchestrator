using Shared.DTO.Users;
using Shared.Interfaces;

namespace AuthService.Interfaces.Users
{
    public interface IUserService : IGenericService<Guid, UserCreateDTO, UserDTO, UserUpdateDTO>
    {
    }
}
