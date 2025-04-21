using AuthService.Interfaces.Users;
using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shared.Config;
using Shared.Consts.Claims;
using Shared.DTO.Users;
using Shared.Exceptions.Users;
using Shared.Models;
using Shared.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthService.Services
{
    public class UserService(IUserRepository repository, IMapper mapper, IOptions<Configuration> configuration)
        : GenericService<IUserRepository, Guid, User, UserCreateDTO, UserDTO, UserUpdateDTO>(repository, mapper),
        IUserService
    {
        private readonly JwtSettings _jwtSettings = configuration.Value.Jwt;

        public async Task<string?> LoginAsync(UserLoginDTO credentials)
        {
            var user = await repository.GetByEmailAsync(credentials.Email) 
                ?? throw new NotFoundByEmailException(credentials.Email);

            if (!user.Password.Equals(credentials.Password))
                throw new ArgumentException("Incorrect password.");

            var token = GenerateJwtSecurityToken(credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private JwtSecurityToken GenerateJwtSecurityToken(UserLoginDTO credentials)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, credentials.Email),
                new Claim(ClaimTypes.Role, ClaimConsts.UserRole)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return token;
        }
    }
}
