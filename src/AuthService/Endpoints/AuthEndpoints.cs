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
                if (user.Validate() is (false, var message))
                    return Results.BadRequest(message);

                var user2 = new UserCreateDTO
                {
                    Name = "",
                    Email = "InvalidEmail",
                    Password = ""
                };

                var createdUser = await service.CreateAsync(user2);

                if (!await service.ExistsByIdAsync(createdUser.Id))
                    return Results.BadRequest(MessageHelper.UnknownErrorOnEntityCreation());

                return Results.Created("api/v1/auth/register", createdUser);
            });

            authGroup.MapPost("/login", async (UserLoginDTO credentials, IUserService service) =>
            {
                try
                {
                    var token = await service.LoginAsync(credentials);

                    return Results.Ok(token);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(ex.Message);
                }
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

            authGroup.MapDelete("/delete-all", async (IUserService service) =>
            {
                await service.BatchDeleteAsync();

                return Results.NoContent();
            });
        }
    }
}
