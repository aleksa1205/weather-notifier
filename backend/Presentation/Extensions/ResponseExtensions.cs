using FluentResults;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Presentation.Extensions;

public static class ResponseExtensions
{
    internal static TResponse? GetMetadata<TResponse>(this IError error, string key)
    {
        if (error.Metadata is null)
            return default;

        if (error.Metadata.TryGetValue(key, out var value) && value is TResponse typedValue)
            return typedValue;

        return default;
    }

    public static IResult ToResponse<TResponse>(this Result<TResponse> result)
    {
        if (result.IsSuccess)
            return Results.Ok(result.Value);

        var error = result.Errors.FirstOrDefault();
        var statusCode = error?.GetMetadata<int>("StatusCode") ?? StatusCodes.Status400BadRequest;

        return Results.Problem(error?.Message ?? "Unkown error", statusCode: statusCode);
    }
}
