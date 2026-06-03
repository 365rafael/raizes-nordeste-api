using Microsoft.EntityFrameworkCore;
using RaizesNordeste.Domain.Entities;
using RaizesNordeste.Domain.Interfaces;
using RaizesNordeste.Infrastructure.Data;

namespace RaizesNordeste.Infrastructure.Repositories;

public class PedidoRepository : IPedidoRepository
{
    private readonly AppDbContext _context;

    public PedidoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Pedido>> ObterTodosAsync()
    {
        return await _context.Pedidos
            .Include(x => x.Cliente)
            .Include(x => x.Unidade)
            .Include(x => x.Itens)
            .ToListAsync();
    }

    public async Task<Pedido?> ObterPorIdAsync(int id)
    {
        return await _context.Pedidos
            .Include(x => x.Cliente)
            .Include(x => x.Unidade)
            .Include(x => x.Itens)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public void Atualizar(Pedido pedido)
    {
        _context.Pedidos.Update(pedido);
    }

    public async Task AdicionarAsync(Pedido pedido)
    {
        await _context.Pedidos.AddAsync(pedido);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}