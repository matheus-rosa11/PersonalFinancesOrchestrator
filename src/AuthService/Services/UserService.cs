using AuthService.Interfaces.Users;
using AutoMapper;
using Shared.DTO.Users;
using Shared.Models;
using Shared.Services;

namespace AuthService.Services
{
    public class UserService(IUserRepository repository, IMapper mapper) 
        : GenericService<IUserRepository, Guid, User, UserCreateDTO, UserDTO, UserUpdateDTO>(repository, mapper),
        IUserService
    {
    }
}
