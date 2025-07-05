using Application.Common.Interfaces;
using Domain.Primitives;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IServiceProvider _serviceProvider;
    private readonly Dictionary<Type, object> _repositories;

    public UnitOfWork(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
    {
        _dbContext = dbContext;
        _serviceProvider = serviceProvider;
        _repositories = new();
    }

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : RootEntity
    {
        var entityType = typeof(TEntity);
        if (_repositories.ContainsKey(entityType))
        {
            return (IRepository<TEntity>) _repositories[entityType];
        }

        //check if this works correctly
        var repository = _serviceProvider.GetRequiredService<IRepository<TEntity>>();
        _repositories.Add(entityType, repository);
        return repository;
    }
    
    public void SaveChanges()
    {
        _dbContext.SaveChanges();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}