using Microsoft.EntityFrameworkCore;
using RaizesNordeste.Domain.Entities;
using RaizesNordeste.Domain.Enums;

namespace RaizesNordeste.Infrastructure.Data;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        await context.Database.MigrateAsync();

        if (!context.Usuarios.Any())
        {
            context.Usuarios.Add(new Usuario
            {
                Nome = "Administrador",
                Email = "admin@raizesnordeste.com",
                SenhaHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
                Role = RoleEnum.ADMIN
            });
        }

        if (!context.Unidades.Any())
        {
            context.Unidades.Add(new Unidade
            {
                Nome = "Loja Centro"
            });
        }

        await context.SaveChangesAsync();
    }
}