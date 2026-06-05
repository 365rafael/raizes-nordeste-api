using RaizesNordeste.Domain.Entities;

namespace RaizesNordeste.Domain.Interfaces;

public interface IUsuarioRepository
{
    Task<Usuario?> ObterPorEmailAsync(string email);

    Task<Usuario?> ObterPorIdAsync(int id);

    Task AdicionarAsync(Usuario usuario);

    Task SaveChangesAsync();
}