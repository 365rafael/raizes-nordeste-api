using RaizesNordeste.Domain.Entities;

namespace RaizesNordeste.Domain.Interfaces;

public interface IUnidadeRepository
{
    Task<List<Unidade>> ObterTodosAsync();

    Task<Unidade?> ObterPorIdAsync(int id);

    Task AdicionarAsync(Unidade unidade);

    void Atualizar(Unidade unidade);

    void Remover(Unidade unidade);

    Task SaveChangesAsync();
}