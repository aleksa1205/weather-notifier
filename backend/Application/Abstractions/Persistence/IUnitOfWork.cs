using Domain.Primitives;
using Domain.Users;

namespace Application.Abstractions.Persistence;

public interface IUnitOfWork : IDisposable
{
    public IUserRepository Users { get; }
    Task SaveChanges(CancellationToken cancellationToken = default);
}