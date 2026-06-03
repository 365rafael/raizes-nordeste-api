using System.ComponentModel.DataAnnotations;

namespace RaizesNordeste.Application.DTOs.Pedido;

public class PedidoItemCreateDto
{
    [Range(1, int.MaxValue)]
    public int ProdutoId { get; set; }

    [Range(1, 9999)]
    public int Quantidade { get; set; }
}