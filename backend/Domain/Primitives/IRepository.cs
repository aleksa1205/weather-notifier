namespace Domain.Primitives;

public interface IRepository<TEntity> where TEntity : RootEntity
{
    public void Add(TEntity entity);
    public void Delete(TEntity entity);
}