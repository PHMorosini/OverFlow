namespace OverFlow.Domain.Usuario.Entity;

using BCrypt.Net;
using OverFlow.Domain.Usuario.ValueObjects;
using System.ComponentModel.DataAnnotations;

public abstract class UserEntity
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public string Cpf { get; private set; }

    public string Email { get; private set; }

    public string PasswordHash { get; private set; }

    public Tipo Tipo { get; private set; }

    public Turno Turno { get; private set; }

    public bool Ativo { get; private set; }

    public UserEntity() { }

    public UserEntity(int id, string name, string email, string? password,Turno turno,Tipo tipo,bool ativo)
    {
        Id = id;
        Name = name?.ToUpper() ?? throw new ArgumentNullException(nameof(name));
        SetEmail(email);
        SetTipo(tipo);
        SetTurno(turno);
        AtivarDesativar(ativo);

        if (!string.IsNullOrWhiteSpace(password))
            SetPassword(password);
    }

    public void SetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("O E-mail não pode estar vazio.", nameof(email));

        Email = email.Trim();
    }

    public void SetPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("A Senha não pode estar vazia.", nameof(password));

        PasswordHash = BCrypt.HashPassword(password);
    }

    public void SetTipo(Tipo tipo)
    {
        if (tipo == null)
            throw new ArgumentNullException(nameof(tipo)); 
        Tipo = tipo;
    }

    public void SetTurno(Turno turno)
    {
        if (turno == null)
            throw new ArgumentNullException(nameof(turno));
        Turno = turno;
    }

    public bool VerifyPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            return false;

        return BCrypt.Verify(password, PasswordHash);
    }

    public void ChangePassword(string newPassword)
    {
        SetPassword(newPassword);
    }

    public void Edit(UserEntity user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        Name = user.Name?.ToUpper() ?? Name;
        SetEmail(user.Email);
        SetTipo(user.Tipo);
        SetTurno(user.Turno);
        AtivarDesativar(user.Ativo);
    }

    public void SetCpf(string cpf)
    {
        if (!IsCpfValido(cpf))
            throw new ArgumentException("CPF inválido.");

        Cpf = new string(cpf.Where(char.IsDigit).ToArray());
    }

    public bool IsCpfValido(string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf))
            return false;

        cpf = new string(cpf.Where(char.IsDigit).ToArray());

        if (cpf.Length != 11)
            return false;

        // Elimina CPFs com todos os números iguais
        if (cpf.Distinct().Count() == 1)
            return false;

        // Primeiro dígito verificador
        int soma = 0;
        for (int i = 0; i < 9; i++)
            soma += (cpf[i] - '0') * (10 - i);

        int resto = soma % 11;
        int digito1 = resto < 2 ? 0 : 11 - resto;

        if (cpf[9] - '0' != digito1)
            return false;

        // Segundo dígito verificador
        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += (cpf[i] - '0') * (11 - i);

        resto = soma % 11;
        int digito2 = resto < 2 ? 0 : 11 - resto;

        if (cpf[10] - '0' != digito2)
            return false;

        return true;
    }


    public void AtivarDesativar (bool ativo)
    {
       Ativo = ativo;
    }
}
