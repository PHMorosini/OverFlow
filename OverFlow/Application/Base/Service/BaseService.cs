using AutoMapper;
using OverFlow.Application.Base.Interface;
using OverFlow.Infrastructure.Base.Interface;

namespace OverFlow.Application.Base.Service;
public class BaseService<TEntity, TViewModel> : IBaseService<TEntity, TViewModel>
    where TEntity : class
    where TViewModel : class
   
{
    private readonly IMapper _mapper;
    private readonly IBaseRepository<TEntity> _repository;

    public BaseService(IMapper mapper, IBaseRepository<TEntity> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public void Add(TViewModel vm)
    {
       var entity = _mapper.Map<TEntity>(vm);
        _repository.Add(entity);
        _repository.SaveChanges();
    }

    public void Delete(object id)
    {
        var entity = _repository.GetById(id);
        entity = _mapper.Map<TEntity>(entity);

        _repository.Delete(entity);
        _repository.SaveChanges();
    }

    public IEnumerable<TViewModel> GetAll()
    {
        //DEPOIS RESOLVE ESSA COISA FEIA AQUI

        var entities = _repository.GetAll();
        entities = (IEnumerable<TEntity>)_mapper.Map<IEnumerable<TViewModel>>(entities);
        return (IEnumerable<TViewModel>)entities;
    }

    public TViewModel GetById(object id)
    {
        var entity = _repository.GetById(id);
        return _mapper.Map<TViewModel>(entity);
    }

    public void Update(TViewModel vm)
    {
        var entity = _mapper.Map<TEntity>(vm);
        _repository.Update(entity);
        _repository.SaveChanges();
    }
}
