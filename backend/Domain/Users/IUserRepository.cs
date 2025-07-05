namespace Domain.Users;
public interface IUserRepository
{
    Task<User?> GetById(Guid id, CancellationToken cancellationToken);
    Task<User?> GetByEmail(string email, CancellationToken cancellationToken);
    void Add(User user);
    void Delete(User user);
}