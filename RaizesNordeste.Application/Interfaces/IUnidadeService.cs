using RaizesNordeste.Application.DTOs.Unidade;

namespace RaizesNordeste.Application.Interfaces;

public interface IUnidadeService
{
    Task<List<UnidadeResponseDto>> ObterTodosAsync();

    Task<UnidadeResponseDto?> ObterPorIdAsync(int id);

    Task<int> CriarAsync(UnidadeCreateDto dto);

    Task AtualizarAsync(int id, UnidadeUpdateDto dto);

    Task RemoverAsync(int id);
}