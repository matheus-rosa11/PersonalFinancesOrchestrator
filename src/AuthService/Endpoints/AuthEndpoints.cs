using AuthService.Interfaces.Users;
using Shared.DTO.Users;
using Shared.Utils.Extensions;
using Shared.Utils.Helpers;

namespace AuthService.Endpoints
{
    public static class AuthEndpoints
    {
        public static void RegisterAuthEndpoints(this IEndpointRouteBuilder routes)
        {
            var authGroup = routes.MapGroup("api/v1/auth");

            authGroup.MapPost("/register", async (UserCreateDTO user, IUserService service) =>
            {
                if (!user.Validate())
                    return Results.BadRequest("Invalid user.");

                var createdUser = await service.CreateAsync(user);

                if (!await service.ExistsByIdAsync(createdUser.Id))
                    return Results.BadRequest(MessageHelper.UnknownErrorOnEntityCreation());

                return Results.Created("api/v1/auth/register", createdUser);
            });

            authGroup.MapPost("/login", async (UserLoginDTO credentials, IUserService service) =>
            {
                var token = await service.LoginAsync(credentials);

                return Results.Ok(token);
            });

            authGroup.MapGet("/get-by-id", async (Guid id, IUserService service) =>
            {
                var user = await service.GetAsync(id);

                if (user is null)
                    return Results.BadRequest(MessageHelper.EntityNotFound(id));

                return Results.Ok(user);
            });

            authGroup.MapGet("/get-all", async (IUserService service) =>
            {
                var users = await service.BatchGetAsync();

                if (!users.SafeAny())
                    return Results.NoContent();

                return Results.Ok(users);
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
