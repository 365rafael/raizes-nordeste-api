using RaizesNordeste.Application.DTOs.Pedido;

namespace RaizesNordeste.Application.Interfaces;

public interface IPedidoService
{
    Task<List<PedidoResponseDto>> ObterTodosAsync();

    Task<int> CriarAsync(PedidoCreateDto dto);
}