namespace OverFlow.Domain.Merenda.Entity;
public class Merenda
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public string Descricao { get; set; }

    public Merenda() {}

    public Merenda(int id, DateTime data, string descricao)
    {
        Id = id;
        Data = data;
        Descricao = descricao;
    }
}
