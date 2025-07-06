using Domain.Primitives;

namespace Domain.Users;
public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmail(string email, CancellationToken cancellationToken = default);
}