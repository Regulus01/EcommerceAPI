using Domain.Inventario.Entities;
using Infra.Core.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Inventario.Maps;

public class CategoriaMap : BaseDomainMap<Categoria>
{
    public override void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.Property(x => x.Nome)
            .HasColumnName("Cat_Nome")
            .IsRequired();
        
        builder.ToTable("Categoria", "Inventario");
    }
}