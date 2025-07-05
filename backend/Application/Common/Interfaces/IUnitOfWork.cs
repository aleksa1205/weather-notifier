using Domain.Primitives;

namespace Application.Common.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : RootEntity;
    void SaveChanges();
}