using RaizesNordeste.Application.DTOs.Produto;

namespace RaizesNordeste.Application.Interfaces;

public interface IProdutoService
{
    Task<List<ProdutoResponseDto>> ObterTodosAsync();

    Task<ProdutoResponseDto?> ObterPorIdAsync(int id);

    Task<int> CriarAsync(ProdutoCreateDto dto);

    Task AtualizarAsync(int id, ProdutoUpdateDto dto);

    Task RemoverAsync(int id);
}