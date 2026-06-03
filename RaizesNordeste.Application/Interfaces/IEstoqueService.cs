using RaizesNordeste.Application.DTOs.Estoque;

namespace RaizesNordeste.Application.Interfaces;

public interface IEstoqueService
{
    Task<List<EstoqueResponseDto>> ObterTodosAsync();

    Task<int> CriarAsync(EstoqueCreateDto dto);

    Task EntradaAsync(int estoqueId, int quantidade);

    Task SaidaAsync(int estoqueId, int quantidade);
}