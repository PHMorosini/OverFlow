
namespace OverFlow.Domain.Administrador.Entity;

using OverFlow.Domain.Usuario.Entity;
using OverFlow.Domain.Usuario.ValueObjects;

public class Administrador : UserEntity
{
    public Administrador(string name, string email, string password, Turno turno, int turmaId)
        : base(
        id: 0,
        name: name,
        email: email,
        password: password,
        turno: turno,
        tipo: Tipo.Aluno,
        ativo: true
        )
    {
        
    }

    public Administrador() { }
}