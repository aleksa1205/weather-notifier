using Domain.Primitives;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

internal abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : RootEntity
{
    protected readonly ApplicationDbContext DbContext;
    
    protected Repository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<TEntity?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await DbContext.Set<TEntity>().SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
    
    public void Add(TEntity entity)
    {
        DbContext.Set<TEntity>().Add(entity);
    }

    public void Delete(TEntity entity)
    {
        DbContext.Set<TEntity>().Remove(entity);
    }
}
