using RaizesNordeste.Domain.Enums;

namespace RaizesNordeste.Domain.Entities;

public class Pedido
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public Usuario Cliente { get; set; } = null!;

    public int UnidadeId { get; set; }

    public Unidade Unidade { get; set; } = null!;

    public CanalPedidoEnum CanalPedido { get; set; }

    public StatusPedidoEnum Status { get; set; }

    public decimal Total { get; set; }

    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

    public ICollection<ItemPedido> Itens { get; set; } = new List<ItemPedido>();

    public Pagamento? Pagamento { get; set; }
}