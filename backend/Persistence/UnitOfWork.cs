using Application.Common.Interfaces;
using Domain.Primitives;
using Domain.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IServiceProvider _serviceProvider;

    public UnitOfWork(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
    {
        _dbContext = dbContext;
        _serviceProvider = serviceProvider;
    }
    
    public IUserRepository  Users => _serviceProvider.GetRequiredService<IUserRepository>();

    public void SaveChanges() => _dbContext.SaveChanges();

    public void Dispose() => _dbContext.Dispose();
}