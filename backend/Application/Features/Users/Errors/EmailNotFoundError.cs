using FluentResults;

namespace Application.Features.Users.Errors;

public class EmailNotFoundError : Error
{
    public EmailNotFoundError(string email) : base($"User with email {email} not found.") 
    {
        Metadata.Add("StatusCode", 404);
    }
}
