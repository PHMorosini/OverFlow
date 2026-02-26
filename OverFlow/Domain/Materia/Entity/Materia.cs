namespace OverFlow.Domain.Materia.Entity;
using OverFlow.Domain.Professor.Entity;
using OverFlow.Domain.Turma.Entity;
public class Materia
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int ProfessorId { get; set; }
    public Professor Professor { get; set; }

    public Materia()
    {
    }

    public Materia(string nome, int professorId)
    {
        Nome = nome;
        ProfessorId = professorId;
    }
}
