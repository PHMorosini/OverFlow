namespace OverFlow.Domain.Aluno.Entity;
using OverFlow.Domain.Turma.Entity;
using OverFlow.Domain.Usuario.Entity;
using OverFlow.Domain.Usuario.ValueObjects;

public class Aluno : UserEntity
{
    public int TurmaId { get; set; }
    public Turma Turma { get; set; }

    protected Aluno() { }
    public Aluno(string name,string email,string password,Turno turno,int turmaId) 
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
        DefinirTurma(turmaId);
    }

    public void DefinirTurma(int turmaId)
    {
        if (turmaId <= 0)
            throw new ArgumentException("Turma inválida");

        TurmaId = turmaId;
    }

}

