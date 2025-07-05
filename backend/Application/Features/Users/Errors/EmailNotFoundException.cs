namespace Application.Features.Users.Errors;

public class EmailNotFoundException : Exception
{
    public EmailNotFoundException(string email) : base($"User with email {email} not found") { }
}
