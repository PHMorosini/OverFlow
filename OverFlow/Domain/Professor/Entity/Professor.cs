
namespace OverFlow.Domain.Professor.Entity;

using OverFlow.Domain.Materia.Entity;
using OverFlow.Domain.Turma.Entity;
using OverFlow.Domain.Usuario.Entity;
using OverFlow.Domain.Usuario.ValueObjects;

public class Professor : UserEntity
{
    public List<Materia> Materias { get; set; } = new ();

    public Professor() { }

    public Professor(List<Materia> materias,string name,string email,string password, Turno turno,int turmaId) 
        : base (
        id: 0,
        name: name,
        email: email,
        password: password,
        turno: turno,
        tipo: Tipo.Aluno,
        ativo: true
       
        )
    {
        Materias = materias;
    }

}