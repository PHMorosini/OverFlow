using OverFlow.Domain.Usuario.ValueObjects;
using OverFlow.Infrastructure.Base.Interface;
using System.Collections.Generic;
using UsuarioEntity = OverFlow.Domain.Usuario.Entity.UserEntity;

namespace OverFlow.Infrastructure.Usuario.Interface;
public interface IUsuarioRepository : IBaseRepository<UsuarioEntity>
{
    public UsuarioEntity ObterPorEmail(string email);

    public IEnumerable<UsuarioEntity> ObterPorTipo(Tipo tipo);
}
