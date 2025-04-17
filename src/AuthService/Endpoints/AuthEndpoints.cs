using AuthService.Interfaces.Users;
using Shared.DTO.Users;

namespace AuthService.Endpoints
{
    public static class AuthEndpoints
    {
        public static void RegisterAuthEndpoints(this IEndpointRouteBuilder routes)
        {
            var authGroup = routes.MapGroup("api/v1/auth");

            authGroup.MapPost("/register", async (UserCreateDTO user, IUserService service) =>
            {
                if (!user.ValidateCreation())
                    return Results.BadRequest();

                var createdUser = await service.CreateAsync(user);

                if (!await service.ExistsByIdAsync(createdUser.Id))
                    return Results.BadRequest("An unknown error ocurred while trying to create a new entity");

                return Results.Created("api/v1/auth/register", createdUser);
            });
        }
    }
}
