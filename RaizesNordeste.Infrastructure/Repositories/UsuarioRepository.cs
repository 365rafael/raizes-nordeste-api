using Microsoft.EntityFrameworkCore;
using RaizesNordeste.Domain.Entities;
using RaizesNordeste.Domain.Interfaces;
using RaizesNordeste.Infrastructure.Data;

namespace RaizesNordeste.Infrastructure.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Usuario?> ObterPorEmailAsync(string email)
    {
        return await _context.Usuarios
            .FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task AdicionarAsync(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}