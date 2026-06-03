using RaizesNordeste.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace RaizesNordeste.Application.DTOs.Pedido;

public class PedidoCreateDto
{
    [Range(1, int.MaxValue)]
    public int ClienteId { get; set; }

    [Range(1, int.MaxValue)]
    public int UnidadeId { get; set; }

    public CanalPedidoEnum CanalPedido { get; set; }

    [MinLength(1,
        ErrorMessage = "Pedido deve possuir ao menos um item.")]
    public List<PedidoItemCreateDto> Itens { get; set; }
        = new();
}