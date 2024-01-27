using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutoDomain = Domain.Authentication.Inventario.Entities.Produto;

namespace Infra.Data.Inventario.Maps;

public class ProdutoMap : IEntityTypeConfiguration<ProdutoDomain>
{
    public void Configure(EntityTypeBuilder<ProdutoDomain> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("Pro_Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Nome)
            .HasColumnName("Pro_Nome")
            .IsRequired();

        builder.Property(x => x.Preco)
            .HasColumnName("Pro_Preco")
            .IsRequired();
        
        builder.Property(x => x.CategoriaId)
            .HasColumnName("Cat_CategoriaId")
            .IsRequired();

        builder.HasOne(x => x.Categoria)
               .WithMany(x => x.Produtos)
               .HasForeignKey(x => x.CategoriaId);
        
        builder.ToTable("Produto", "Inventario");
    }
}