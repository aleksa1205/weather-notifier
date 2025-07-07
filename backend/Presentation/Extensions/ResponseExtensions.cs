using FluentResults;

namespace Presentation.Extensions;

//should check if there is a better way
public static class ResponseExtensions
{
    private static TResponse? GetMetadata<TResponse>(this IError error, string key)
    {
        if (error.Metadata is null)
            return default;

        if (error.Metadata.TryGetValue(key, out var value) && value is TResponse typedValue)
            return typedValue;

        return default;
    }

    private static IResult GetProblemDetails<TResponse>(this Result<TResponse> result)
    {
        var error = result.Errors.FirstOrDefault();
        var statusCode = error?.GetMetadata<int>("StatusCode") ?? StatusCodes.Status400BadRequest;
        return Results.Problem(error?.Message ?? "Unkown error", statusCode: statusCode);
    }


    public static IResult ToResponse<TResponse>(this Result<TResponse> result)
    {
        if (result.IsSuccess)
            return Results.Ok(result.Value);
        return result.GetProblemDetails();
    }
}