using RaizesNordeste.Domain.Entities;

namespace RaizesNordeste.Domain.Interfaces;

public interface IPagamentoRepository
{
    Task<Pagamento?> ObterPorPedidoIdAsync(int pedidoId);

    Task AdicionarAsync(Pagamento pagamento);

    Task SaveChangesAsync();
}