using Microsoft.EntityFrameworkCore;
using OverFlow.Infrastructure.Base.Interface;

namespace OverFlow.Infrastructure.Base.Repository;
public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public BaseRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public virtual TEntity GetById(object id)
    {
        return _dbSet.Find(id);
    }

    public virtual IEnumerable<TEntity> GetAll()
    {
        return _dbSet.ToList();
    }

    public virtual void Add(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public virtual void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public virtual void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public virtual void SaveChanges()
    {
        _context.SaveChanges();
    }
}