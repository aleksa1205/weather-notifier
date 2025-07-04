namespace Domain.Users;
public interface IUserRepository
{
    Task<User?> GetById(Guid id);
    Task<User?> GetByEmail(string email);
    void Add(User user);
    void Delete(User user);
}