namespace OverFlow.Application.Base.Interface;
public interface IBaseService<TEntity, TViewModel>
    where TEntity : class
    where TViewModel : class
{

    public TViewModel GetById(object id);
    public IEnumerable<TViewModel> GetAll();
    public void Add(TViewModel vm);
    public void Update(TViewModel vm);
    public void Delete(object id);
}
