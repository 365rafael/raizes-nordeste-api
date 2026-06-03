using RaizesNordeste.Domain.Entities;

namespace RaizesNordeste.Domain.Interfaces;

public interface IEstoqueRepository
{
    Task<List<Estoque>> ObterTodosAsync();

    Task<Estoque?> ObterPorIdAsync(int id);

    Task<Estoque?> ObterPorProdutoUnidadeAsync(
        int produtoId,
        int unidadeId);

    Task AdicionarAsync(Estoque estoque);

    void Atualizar(Estoque estoque);

    Task SaveChangesAsync();
}