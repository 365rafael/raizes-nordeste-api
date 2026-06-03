using RaizesNordeste.Domain.Enums;

namespace RaizesNordeste.Application.DTOs.Pedido;

public class PedidoCreateDto
{
    public int ClienteId { get; set; }

    public int UnidadeId { get; set; }

    public CanalPedidoEnum CanalPedido { get; set; }

    public List<PedidoItemCreateDto> Itens { get; set; }
        = new();
}