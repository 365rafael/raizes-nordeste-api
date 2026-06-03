using RaizesNordeste.Application.DTOs.Unidade;
using RaizesNordeste.Application.Interfaces;
using RaizesNordeste.Domain.Entities;
using RaizesNordeste.Domain.Interfaces;

namespace RaizesNordeste.Application.Services;

public class UnidadeService : IUnidadeService
{
    private readonly IUnidadeRepository _unidadeRepository;

    public UnidadeService(IUnidadeRepository unidadeRepository)
    {
        _unidadeRepository = unidadeRepository;
    }

    public async Task<List<UnidadeResponseDto>> ObterTodosAsync()
    {
        var unidades = await _unidadeRepository.ObterTodosAsync();

        return unidades.Select(x => new UnidadeResponseDto
        {
            Id = x.Id,
            Nome = x.Nome,
            Cidade = x.Cidade,
            Estado = x.Estado
        }).ToList();
    }

    public async Task<UnidadeResponseDto?> ObterPorIdAsync(int id)
    {
        var unidade = await _unidadeRepository.ObterPorIdAsync(id);

        if (unidade == null)
            return null;

        return new UnidadeResponseDto
        {
            Id = unidade.Id,
            Nome = unidade.Nome,
            Cidade = unidade.Cidade,
            Estado = unidade.Estado
        };
    }

    public async Task<int> CriarAsync(UnidadeCreateDto dto)
    {
        var unidade = new Unidade
        {
            Nome = dto.Nome,
            Cidade = dto.Cidade,
            Estado = dto.Estado
        };

        await _unidadeRepository.AdicionarAsync(unidade);
        await _unidadeRepository.SaveChangesAsync();

        return unidade.Id;
    }

    public async Task AtualizarAsync(int id, UnidadeUpdateDto dto)
    {
        var unidade = await _unidadeRepository.ObterPorIdAsync(id);

        if (unidade == null)
            throw new Exception("Unidade não encontrada.");

        unidade.Nome = dto.Nome;
        unidade.Cidade = dto.Cidade;
        unidade.Estado = dto.Estado;

        _unidadeRepository.Atualizar(unidade);

        await _unidadeRepository.SaveChangesAsync();
    }

    public async Task RemoverAsync(int id)
    {
        var unidade = await _unidadeRepository.ObterPorIdAsync(id);

        if (unidade == null)
            throw new Exception("Unidade não encontrada.");

        _unidadeRepository.Remover(unidade);

        await _unidadeRepository.SaveChangesAsync();
    }
}