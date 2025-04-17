using AuthService.Interfaces.Users;
using AutoMapper;
using Shared.DTO.Users;
using Shared.Models;

namespace AuthService.Services
{
    public class UserService(IUserRepository repository, IMapper mapper) : IUserService
    {
        public async Task<UserDTO> CreateAsync(UserCreateDTO createDTO)
        {
            ArgumentNullException.ThrowIfNull(createDTO);

            createDTO.SetCreatedDate(DateTime.UtcNow);

            return mapper.Map<UserDTO>(await repository.CreateAsync(mapper.Map<User>(createDTO)));
        }

        public async Task<UserDTO> GetByIdAsync(Guid key)
        {
            return mapper.Map<UserDTO>(await repository.GetByIdAsync(key));
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync(int? limit = 0)
        {
            return mapper.Map<IEnumerable<UserDTO>>(await repository.GetAllAsync(limit));
        }

        public async Task<bool> ExistsByIdAsync(Guid key)
        {
            return await repository.ExistsByIdAsync(key);
        }

        public async Task UpdateAsync(Guid key, UserUpdateDTO updateDTO)
        {
            await repository.UpdateAsync(key, mapper.Map<User>(updateDTO));
        }

        public async Task DeleteAsync(Guid key)
        {
            await repository.DeleteAsync(key);
        }
    }
}
