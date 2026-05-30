using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RaizesNordeste.Domain.Entities;

namespace RaizesNordeste.Infrastructure.Configurations;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produtos");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.Descricao)
            .HasMaxLength(500);

        builder.Property(x => x.Preco)
            .HasPrecision(18, 2);

        builder.Property(x => x.Ativo)
            .HasDefaultValue(true);
    }
}