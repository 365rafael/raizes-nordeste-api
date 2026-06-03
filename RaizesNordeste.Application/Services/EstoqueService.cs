using RaizesNordeste.Application.DTOs.Estoque;
using RaizesNordeste.Application.Interfaces;
using RaizesNordeste.Domain.Entities;
using RaizesNordeste.Domain.Interfaces;

namespace RaizesNordeste.Application.Services;

public class EstoqueService : IEstoqueService
{
    private readonly IEstoqueRepository _estoqueRepository;

    public EstoqueService(
        IEstoqueRepository estoqueRepository)
    {
        _estoqueRepository = estoqueRepository;
    }

    public async Task<List<EstoqueResponseDto>> ObterTodosAsync()
    {
        var estoques =
            await _estoqueRepository.ObterTodosAsync();

        return estoques.Select(x => new EstoqueResponseDto
        {
            Id = x.Id,
            ProdutoId = x.ProdutoId,
            Produto = x.Produto.Nome,
            UnidadeId = x.UnidadeId,
            Unidade = x.Unidade.Nome,
            Quantidade = x.Quantidade
        }).ToList();
    }

    public async Task<int> CriarAsync(
        EstoqueCreateDto dto)
    {
        var existente =
            await _estoqueRepository
                .ObterPorProdutoUnidadeAsync(
                    dto.ProdutoId,
                    dto.UnidadeId);

        if (existente != null)
            throw new Exception(
                "Já existe estoque para este produto nesta unidade.");

        var estoque = new Estoque
        {
            ProdutoId = dto.ProdutoId,
            UnidadeId = dto.UnidadeId,
            Quantidade = dto.Quantidade
        };

        await _estoqueRepository.AdicionarAsync(estoque);

        await _estoqueRepository.SaveChangesAsync();

        return estoque.Id;
    }

    public async Task EntradaAsync(
        int estoqueId,
        int quantidade)
    {
        var estoque =
            await _estoqueRepository
                .ObterPorIdAsync(estoqueId);

        if (estoque == null)
            throw new Exception("Estoque não encontrado.");

        estoque.Quantidade += quantidade;

        _estoqueRepository.Atualizar(estoque);

        await _estoqueRepository.SaveChangesAsync();
    }

    public async Task SaidaAsync(
        int estoqueId,
        int quantidade)
    {
        var estoque =
            await _estoqueRepository
                .ObterPorIdAsync(estoqueId);

        if (estoque == null)
            throw new Exception("Estoque não encontrado.");

        if (estoque.Quantidade < quantidade)
            throw new Exception("Estoque insuficiente.");

        estoque.Quantidade -= quantidade;

        _estoqueRepository.Atualizar(estoque);

        await _estoqueRepository.SaveChangesAsync();
    }
}