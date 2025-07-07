using FluentResults;

namespace Application.Features.Users.Errors
{
    public class DuplicateEmailError : Error
    {
        public DuplicateEmailError(string email) : base($"Email {email} already exists.") 
        {
            Metadata.Add("StatusCode", 409);
        }
    }
}
