using Domain.Primitives;
using Domain.Users;

namespace Application.Common.Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IUserRepository Users { get; }
    void SaveChanges();
}