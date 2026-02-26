namespace OverFlow.Domain.ReservaLaboratorio.Entity;
using OverFlow.Domain.Materia.Entity;
using OverFlow.Domain.Laboratorio.Entity;
using OverFlow.Domain.Professor.Entity;
using System.ComponentModel.DataAnnotations;

public class ReservaLaboratorio
{
    [Key]
    public int Id { get; set; }
    public int LaboratorioId { get; set; }
    public int MateriaId { get; set; }
    public int ProfessorId { get; set; }
    public DateTime DataHora { get; set; }
    public virtual Laboratorio Laboratorio { get; set; }
    public virtual Materia Materia { get; set; }
    public virtual Professor Professor { get; set; }

    public ReservaLaboratorio(int id, int laboratorioId, int materiaId, int professorId, DateTime dataHora, Laboratorio laboratorio, Materia materia, Professor professor)
    {
        Id = id;
        LaboratorioId = laboratorioId;
        MateriaId = materiaId;
        ProfessorId = professorId;
        DataHora = dataHora;
        Laboratorio = laboratorio;
        Materia = materia;
        Professor = professor;
    }

    public ReservaLaboratorio() {}
}
