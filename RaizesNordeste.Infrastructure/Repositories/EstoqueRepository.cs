using Microsoft.EntityFrameworkCore;
using RaizesNordeste.Domain.Entities;
using RaizesNordeste.Domain.Interfaces;
using RaizesNordeste.Infrastructure.Data;

namespace RaizesNordeste.Infrastructure.Repositories;

public class EstoqueRepository : IEstoqueRepository
{
    private readonly AppDbContext _context;

    public EstoqueRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Estoque>> ObterTodosAsync()
    {
        return await _context.Estoques
            .Include(x => x.Produto)
            .Include(x => x.Unidade)
            .ToListAsync();
    }

    public async Task<Estoque?> ObterPorIdAsync(int id)
    {
        return await _context.Estoques
            .Include(x => x.Produto)
            .Include(x => x.Unidade)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Estoque?> ObterPorProdutoUnidadeAsync(
        int produtoId,
        int unidadeId)
    {
        return await _context.Estoques
            .FirstOrDefaultAsync(x =>
                x.ProdutoId == produtoId &&
                x.UnidadeId == unidadeId);
    }

    public async Task AdicionarAsync(Estoque estoque)
    {
        await _context.Estoques.AddAsync(estoque);
    }

    public void Atualizar(Estoque estoque)
    {
        _context.Estoques.Update(estoque);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}