using AuthService.Interfaces.Users;
using Shared.DTO.Users;
using Shared.Repositories;

namespace AuthService.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<UserDTO> CreateAsync(UserCreateDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync(int? limit = 0)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsByIdAsync(Guid key)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Guid id, UserUpdateDTO updateDTO)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
