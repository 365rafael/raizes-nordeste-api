using Microsoft.EntityFrameworkCore;
using RaizesNordeste.Domain.Entities;
using RaizesNordeste.Domain.Interfaces;
using RaizesNordeste.Infrastructure.Data;

namespace RaizesNordeste.Infrastructure.Repositories;

public class UnidadeRepository : IUnidadeRepository
{
    private readonly AppDbContext _context;

    public UnidadeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Unidade>> ObterTodosAsync()
    {
        return await _context.Unidades.ToListAsync();
    }

    public async Task<Unidade?> ObterPorIdAsync(int id)
    {
        return await _context.Unidades
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AdicionarAsync(Unidade unidade)
    {
        await _context.Unidades.AddAsync(unidade);
    }

    public void Atualizar(Unidade unidade)
    {
        _context.Unidades.Update(unidade);
    }

    public void Remover(Unidade unidade)
    {
        _context.Unidades.Remove(unidade);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}