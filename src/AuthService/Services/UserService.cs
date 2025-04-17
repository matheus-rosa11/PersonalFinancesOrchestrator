using AuthService.Interfaces.Users;
using AuthService.Repositories;
using Shared.DTO.Users;

namespace AuthService.Services
{
    public class UserService(UserRepository repository) : IUserService
    {
        public async Task<UserDTO> CreateAsync(UserCreateDTO createDTO)
        {
            return await repository.CreateAsync(createDTO);
        }

        public async Task<UserDTO> GetByIdAsync(Guid key)
        {
            return await repository.GetByIdAsync(key);
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync(int? limit = 0)
        {
            return await repository.GetAllAsync(limit);
        }

        public async Task<bool> ExistsByIdAsync(Guid key)
        {
            return await repository.ExistsByIdAsync(key);
        }

        public async Task UpdateAsync(Guid key, UserUpdateDTO updateDTO)
        {
            await repository.UpdateAsync(key, updateDTO);
        }

        public async Task DeleteAsync(Guid key)
        {
            await repository.DeleteAsync(key);
        }
    }
}
