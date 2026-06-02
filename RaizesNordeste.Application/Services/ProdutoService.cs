using RaizesNordeste.Application.DTOs.Produto;
using RaizesNordeste.Application.Interfaces;
using RaizesNordeste.Domain.Entities;
using RaizesNordeste.Domain.Interfaces;

namespace RaizesNordeste.Application.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<List<ProdutoResponseDto>> ObterTodosAsync()
    {
        var produtos = await _produtoRepository.ObterTodosAsync();

        return produtos.Select(p => new ProdutoResponseDto
        {
            Id = p.Id,
            Nome = p.Nome,
            Descricao = p.Descricao,
            Preco = p.Preco,
            Ativo = p.Ativo
        }).ToList();
    }

    public async Task<ProdutoResponseDto?> ObterPorIdAsync(int id)
    {
        var produto = await _produtoRepository.ObterPorIdAsync(id);

        if (produto == null)
            return null;

        return new ProdutoResponseDto
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            Preco = produto.Preco,
            Ativo = produto.Ativo
        };
    }

    public async Task<int> CriarAsync(ProdutoCreateDto dto)
    {
        if (dto.Preco <= 0)
            throw new Exception("Preço deve ser maior que zero.");

        var produto = new Produto
        {
            Nome = dto.Nome,
            Descricao = dto.Descricao,
            Preco = dto.Preco,
            Ativo = true
        };

        await _produtoRepository.AdicionarAsync(produto);
        await _produtoRepository.SaveChangesAsync();

        return produto.Id;
    }

    public async Task AtualizarAsync(int id, ProdutoUpdateDto dto)
    {
        var produto = await _produtoRepository.ObterPorIdAsync(id);

        if (produto == null)
            throw new Exception("Produto não encontrado.");

        produto.Nome = dto.Nome;
        produto.Descricao = dto.Descricao;
        produto.Preco = dto.Preco;
        produto.Ativo = dto.Ativo;

        _produtoRepository.Atualizar(produto);

        await _produtoRepository.SaveChangesAsync();
    }

    public async Task RemoverAsync(int id)
    {
        var produto = await _produtoRepository.ObterPorIdAsync(id);

        if (produto == null)
            throw new Exception("Produto não encontrado.");

        _produtoRepository.Remover(produto);

        await _produtoRepository.SaveChangesAsync();
    }
}