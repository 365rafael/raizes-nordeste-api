namespace RaizesNordeste.Domain.Entities;

public class Unidade
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Cidade { get; set; } = string.Empty;

    public string Estado { get; set; } = string.Empty;

    public ICollection<Estoque> Estoques { get; set; } = new List<Estoque>();

    public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}