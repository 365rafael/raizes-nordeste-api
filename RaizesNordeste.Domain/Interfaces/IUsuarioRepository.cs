using RaizesNordeste.Domain.Entities;

namespace RaizesNordeste.Domain.Interfaces;

public interface IUsuarioRepository
{
    Task<Usuario?> ObterPorEmailAsync(string email);

    Task AdicionarAsync(Usuario usuario);

    Task SaveChangesAsync();
}