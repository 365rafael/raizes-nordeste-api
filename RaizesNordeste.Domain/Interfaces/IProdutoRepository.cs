using RaizesNordeste.Domain.Entities;

namespace RaizesNordeste.Domain.Interfaces;

public interface IProdutoRepository
{
    Task<List<Produto>> ObterTodosAsync();

    Task<Produto?> ObterPorIdAsync(int id);

    Task AdicionarAsync(Produto produto);

    void Atualizar(Produto produto);

    void Remover(Produto produto);

    Task SaveChangesAsync();
}