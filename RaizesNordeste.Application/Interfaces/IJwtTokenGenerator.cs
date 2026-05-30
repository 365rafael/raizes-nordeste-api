using RaizesNordeste.Domain.Entities;

namespace RaizesNordeste.Application.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(Usuario usuario);
}