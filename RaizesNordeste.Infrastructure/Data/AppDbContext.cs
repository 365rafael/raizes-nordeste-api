using Microsoft.EntityFrameworkCore;
using RaizesNordeste.Domain.Entities;

namespace RaizesNordeste.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios => Set<Usuario>();

    public DbSet<Produto> Produtos => Set<Produto>();

    public DbSet<Unidade> Unidades => Set<Unidade>();

    public DbSet<Estoque> Estoques => Set<Estoque>();

    public DbSet<Pedido> Pedidos => Set<Pedido>();

    public DbSet<ItemPedido> ItensPedido => Set<ItemPedido>();

    public DbSet<Pagamento> Pagamentos => Set<Pagamento>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}