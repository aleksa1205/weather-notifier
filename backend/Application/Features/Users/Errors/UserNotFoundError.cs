using FluentResults;

namespace Application.Features.Users.Errors;

public class UserNotFoundError : Error
{
    public UserNotFoundError(Guid id) : base($"User with id {id} not found.")
    {
        Metadata.Add("StatusCode", 404);
    }
}
