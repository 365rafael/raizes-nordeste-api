using RaizesNordeste.Application.DTOs.Pagamento;

namespace RaizesNordeste.Application.Interfaces;

public interface IPagamentoService
{
    Task<PagamentoResponseDto> ProcessarPagamentoAsync(
        PagamentoCreateDto dto);
}