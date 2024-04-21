using Infra.Core.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutoDomain = Domain.Inventario.Entities.Produto;

namespace Infra.Data.Inventario.Maps;

public class ProdutoMap : BaseDomainMap<ProdutoDomain>
{
    public override void Configure(EntityTypeBuilder<ProdutoDomain> builder)
    {
        builder.Property(x => x.Nome)
            .HasColumnName("Pro_Nome")
            .IsRequired();

        builder.Property(x => x.Preco)
            .HasColumnName("Pro_Preco")
            .IsRequired();

        builder.Property(x => x.Estoque)
            .HasColumnName("Pro_Estoque")
            .HasDefaultValue(0);
        
        builder.Property(x => x.Descricao)
            .HasColumnName("Pro_Descricao");

        builder.Property(x => x.Classificacao)
            .HasColumnName("Pro_Classificacao")
            .HasMaxLength(1);
            
        builder.Property(x => x.CaminhoFotoDeCapa)
            .HasColumnName("Ger_CaminhoFotoDeCapa");
        
        builder.Property(x => x.CategoriaId)
            .HasColumnName("Cat_CategoriaId")
            .IsRequired();

        builder.HasOne(x => x.Categoria)
               .WithMany(x => x.Produtos)
               .HasForeignKey(x => x.CategoriaId);
        
        builder.ToTable("Produto", "Inventario");
    }
}