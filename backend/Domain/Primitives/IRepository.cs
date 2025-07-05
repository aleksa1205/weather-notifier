namespace Domain.Primitives;

public interface IRepository<TEntity> where TEntity : RootEntity
{
    public Task<TEntity?> GetById(Guid id, CancellationToken cancellationToken = default);
    public void Add(TEntity entity);
    public void Delete(TEntity entity);
}