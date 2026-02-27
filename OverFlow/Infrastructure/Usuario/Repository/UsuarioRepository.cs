using OverFlow.Domain.Usuario.Entity;
using OverFlow.Domain.Usuario.ValueObjects;
using OverFlow.Infrastructure.Base.Repository;
using OverFlow.Infrastructure.Context;
using OverFlow.Infrastructure.Usuario.Interface;

namespace OverFlow.Infrastructure.Usuario.Repository;
public class UsuarioRepository : BaseRepository<UserEntity>, IUsuarioRepository
{
    public UsuarioRepository(AppDbContext context) : base(context)
    {

    }

    public UserEntity ObterPorEmail(string email)
    {
        if(String.IsNullOrEmpty(email))
            throw new ArgumentException("Email inválido");

        return _dbSet.FirstOrDefault(u => u.Email == email);
    }

    public IEnumerable<UserEntity> ObterPorTipo(Tipo tipo)
    {
        if (!Enum.IsDefined(tipo))
        {
            throw new ArgumentException("Tipo inválido");
        }

        return _dbSet.Where(x => x.Tipo == tipo).ToList();
    }
}
