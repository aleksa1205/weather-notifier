using Carter;
using Presentation.Common;
using Presentation.Extensions;

namespace Presentation.Endpoints.Users;

//add response types/result pattern
public class UsersModule : CarterModule
{
    public UsersModule() : base(Constants.Routes.Users.BaseRoute) {}

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/{id}", UserHandlers.GetById)
            .ProducesNotFound();

        app.MapGet("/by-email/{email}", UserHandlers.GetByEmail);
        app.MapPost("/", UserHandlers.Create);
        app.MapDelete("/{id}", UserHandlers.Delete);
    }
}