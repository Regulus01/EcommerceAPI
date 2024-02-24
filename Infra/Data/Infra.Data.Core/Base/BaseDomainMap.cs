using Domain.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Core.Base;

public class BaseDomainMap<TDomain> : IEntityTypeConfiguration<TDomain> where TDomain : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TDomain> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CriadoEm)
            .HasColumnName("Criado_em")
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder.Property(x => x.ModificadoEm)
            .HasColumnName("Moficado_em")
            .ValueGeneratedOnUpdate()
            .IsRequired();
    }
}