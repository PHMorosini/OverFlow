using Microsoft.EntityFrameworkCore;
using OverFlow.Domain.Administrador.Entity;
using OverFlow.Domain.Aluno.Entity;
using OverFlow.Domain.Laboratorio.Entity;
using OverFlow.Domain.Materia.Entity;
using OverFlow.Domain.Merenda.Entity;
using OverFlow.Domain.Professor.Entity;
using OverFlow.Domain.ReservaLaboratorio.Entity;
using OverFlow.Domain.Turma.Entity;
using OverFlow.Domain.Usuario.Entity;

namespace OverFlow.Infrastructure.Context;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Turma> Turmas { get; set; }
    public DbSet<Materia> Materias { get; set; }
    public DbSet<Professor> Professores { get; set; }
    public DbSet<Laboratorio> Laboratorios { get; set; }
    public DbSet<ReservaLaboratorio> ReservasLaboratorio { get; set; }
    public DbSet<Merenda> Merendas { get; set; }
    public DbSet<UserEntity> Usuarios { get; set; }

    public DbSet<Administrador> Administradores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserEntity>(entity =>
        {
            entity.ToTable("Usuarios");
            entity.HasKey(u => u.Id);

            entity.Property(u => u.Id)
                  .ValueGeneratedOnAdd();
            entity.Property(u => u.Name)
                  .IsRequired()
                  .HasMaxLength(150);
            entity.Property(u => u.Email)
                  .IsRequired()
                  .HasMaxLength(150);
            entity.HasIndex(u => u.Email)
                  .IsUnique();
            entity.Property(u => u.PasswordHash)
                  .IsRequired()
                  .HasColumnName("Password");
            entity.Property(u => u.Cpf)
                  .IsRequired()
                  .HasMaxLength(11);
            entity.HasIndex(u => u.Cpf)
                  .IsUnique();
            entity.Property(u => u.Tipo)
                  .HasConversion<int>()
                  .IsRequired();
            entity.Property(u => u.Turno)
                  .HasConversion<int>()
                  .IsRequired();
        });

        modelBuilder.Entity<UserEntity>().ToTable("Usuarios");

        modelBuilder.Entity<Aluno>().ToTable("Alunos");

        modelBuilder.Entity<Professor>().ToTable("Professores");
    }

}
