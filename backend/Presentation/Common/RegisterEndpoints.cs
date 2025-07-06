using Presentation.Endpoints.Users;

namespace Presentation.Common;

public static class RegisterEndpoints
{
    public static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        app.RegisterUserEndpoints();
    }
}