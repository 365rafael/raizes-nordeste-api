using Microsoft.EntityFrameworkCore;
using RaizesNordeste.Domain.Entities;
using RaizesNordeste.Domain.Interfaces;
using RaizesNordeste.Infrastructure.Data;

namespace RaizesNordeste.Infrastructure.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Produto>> ObterTodosAsync()
    {
        return await _context.Produtos.ToListAsync();
    }

    public async Task<Produto?> ObterPorIdAsync(int id)
    {
        return await _context.Produtos
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AdicionarAsync(Produto produto)
    {
        await _context.Produtos.AddAsync(produto);
    }

    public void Atualizar(Produto produto)
    {
        _context.Produtos.Update(produto);
    }

    public void Remover(Produto produto)
    {
        _context.Produtos.Remove(produto);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}