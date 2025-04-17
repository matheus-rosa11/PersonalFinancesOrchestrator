using AuthService.Services;
using Shared.DTO.Users;

namespace AuthService.Endpoints
{
    public static class AuthEndpoints
    {
        public static void RegisterAuthEndpoints(this IEndpointRouteBuilder routes)
        {
            var authGroup = routes.MapGroup("api/v1/auth");

            authGroup.MapPost("/register", async (UserService service, UserCreateDTO user) =>
            {
                if (!user.ValidateCreation())
                    return Results.BadRequest();

                var createdUser = await service.CreateAsync(user);

                if (!await service.ExistsByIdAsync(createdUser.Id))
                    return Results.BadRequest();

                return Results.Created();
            });
        }
    }
}
