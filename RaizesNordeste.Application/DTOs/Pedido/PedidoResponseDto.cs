using RaizesNordeste.Domain.Enums;

namespace RaizesNordeste.Application.DTOs.Pedido;

public class PedidoResponseDto
{
    public int Id { get; set; }

    public string Cliente { get; set; } = string.Empty;

    public string Unidade { get; set; } = string.Empty;

    public decimal Total { get; set; }

    public StatusPedidoEnum Status { get; set; }

    public DateTime DataCriacao { get; set; }
}