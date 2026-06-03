using Microsoft.EntityFrameworkCore;
using RaizesNordeste.Domain.Entities;
using RaizesNordeste.Domain.Interfaces;
using RaizesNordeste.Infrastructure.Data;

namespace RaizesNordeste.Infrastructure.Repositories;

public class PagamentoRepository : IPagamentoRepository
{
    private readonly AppDbContext _context;

    public PagamentoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Pagamento?> ObterPorPedidoIdAsync(int pedidoId)
    {
        return await _context.Pagamentos
            .FirstOrDefaultAsync(x => x.PedidoId == pedidoId);
    }

    public async Task AdicionarAsync(Pagamento pagamento)
    {
        await _context.Pagamentos.AddAsync(pagamento);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}