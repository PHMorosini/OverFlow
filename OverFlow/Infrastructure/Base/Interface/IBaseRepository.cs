namespace OverFlow.Infrastructure.Base.Interface;
public interface IBaseRepository<TEntity> where TEntity : class
{
    TEntity GetById(object id);
    IEnumerable<TEntity> GetAll();
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    void SaveChanges();
}