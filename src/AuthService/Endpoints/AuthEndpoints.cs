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
                    return Results.BadRequest("Invalid user.");

                var createdUser = await service.CreateAsync(user);

                if (!await service.ExistsByIdAsync(createdUser.Id))
                    return Results.BadRequest("An unknown error ocurred while trying to create a new entity.");

                return Results.Created("api/v1/auth/register", createdUser);
            });

            authGroup.MapPost("/login", async (UserLoginDTO credentials, IUserService service) =>
            {
                var token = await service.LoginAsync(credentials);

                return Results.Ok(token);
            });

            authGroup.MapDelete("/delete", async (Guid id, IUserService service) =>
            {
                if (!await service.ExistsByIdAsync(id))
                    return Results.NotFound();

                await service.DeleteAsync(id);

                return Results.NoContent();
            });
        }
    }
}
