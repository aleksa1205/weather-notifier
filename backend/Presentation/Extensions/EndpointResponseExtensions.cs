namespace Presentation.Extensions;

public static class EndpointResponseExtensions
{
    public static RouteHandlerBuilder ProducesBasicResponse(this RouteHandlerBuilder builder)
    {
        return builder
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);
    }

    public static RouteHandlerBuilder ProducesNotFound(this RouteHandlerBuilder builder)
    {
        return builder.Produces(StatusCodes.Status404NotFound);
    }

    public static RouteHandlerBuilder ProducesConflict(this RouteHandlerBuilder builder)
    {
        return builder.Produces(StatusCodes.Status409Conflict);
    }
}
