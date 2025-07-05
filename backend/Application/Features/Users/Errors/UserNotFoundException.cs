namespace Application.Features.Users.Errors;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(Guid id) : base($"User with id {id} not found") { }
}
