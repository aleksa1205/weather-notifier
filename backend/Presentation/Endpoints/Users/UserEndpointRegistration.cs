using Presentation.Common;

namespace Presentation.Endpoints.Users;

//add response types/result pattern
public static class UserEndpointRegistration
{
    public static void RegisterUserEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(Constants.Routes.Users.BaseRoute);
        
        group.MapGet("/{id}", UserController.GetById);
        group.MapGet("/by-email/{email}", UserController.GetByEmail);
        group.MapPost("/", UserController.Create);
        group.MapDelete("/{id}", UserController.Delete);
    }
}