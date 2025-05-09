using AuthService.Interfaces.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using Shared.DTO.Users;
using Shared.Models;
using Shared.Utils.Helpers;

namespace AuthServiceTest
{
    public class AuthEndpointTest
    {
        [Fact]
        public async Task Login_Should_Return_Token_With_Correct_Credentials()
        {
            var mockService = new Mock<IUserService>();

            GenerateFakeUser(out UserCreateDTO user, out UserDTO fakeCreatedUser);

            mockService.Setup(service => service.CreateAsync(It.Is<UserCreateDTO>(createDTO =>
                createDTO.Email == user.Email && createDTO.Password == user.Password && createDTO.Name == user.Name)))
                .ReturnsAsync(fakeCreatedUser);

            var createdUser = mockService.Object.CreateAsync(user);

            var credentials = new UserLoginDTO
            {
                Email = "hagnos@gmail.com",
                Password = "teste123",
            };

            var result = await mockService.Object.LoginAsync(credentials);

            Assert.NotNull(result);
        }

        private static void GenerateFakeUser(out UserCreateDTO user, out UserDTO fakeCreatedUser)
        {
            user = new UserCreateDTO
            {
                Name = "Matheus dos Santos Felix",
                Email = "hagnos@gmail.com",
                Password = "teste123",
            };

            fakeCreatedUser = new UserDTO
            {
                Id = Guid.NewGuid(),
                Name = user.Name,
                Email = user.Email
            };
        }
    }
}