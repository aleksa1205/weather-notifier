using Domain.Primitives;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

internal abstract class Repository<TEntity> where TEntity : RootEntity
{
    protected readonly ApplicationDbContext DbContext;

    protected Repository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
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
