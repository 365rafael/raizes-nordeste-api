using RaizesNordeste.Domain.Entities;

namespace RaizesNordeste.Domain.Interfaces;

public interface IPedidoRepository
{
    Task<List<Pedido>> ObterTodosAsync();

    Task<Pedido?> ObterPorIdAsync(int id);

    Task AdicionarAsync(Pedido pedido);

    void Atualizar(Pedido pedido);

    Task SaveChangesAsync();
}