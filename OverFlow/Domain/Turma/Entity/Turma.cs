
namespace OverFlow.Domain.Turma.Entity;
using OverFlow.Domain.Aluno.Entity;
using OverFlow.Domain.Materia.Entity;
using System.ComponentModel.DataAnnotations;

public class Turma
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public ICollection<Aluno> Alunos { get; set; }

    public Turma(int id, string nome, ICollection<Aluno> alunos)
    {
        Id = id;
        Nome = nome;
        Alunos = alunos;
    }
    public Turma() { }

}
