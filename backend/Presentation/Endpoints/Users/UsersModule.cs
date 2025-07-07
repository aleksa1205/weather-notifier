using Carter;
using Presentation.Common;
using Presentation.Extensions;

namespace Presentation.Endpoints.Users;

public class UsersModule : CarterModule
{
    public UsersModule() : base(Constants.Routes.Users.BaseRoute) {}

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/{id}", UserHandlers.GetById)
            .ProducesBasicResponse()
            .ProducesNotFound();

        app.MapGet("/by-email/{email}", UserHandlers.GetByEmail)
            .ProducesBasicResponse()
            .ProducesNotFound();

        app.MapPost("/", UserHandlers.Create)
            .ProducesBasicResponse()
            .ProducesConflict();

        app.MapDelete("/{id}", UserHandlers.Delete)
            .ProducesBasicResponse()
            .ProducesNotFound();
    }
}