using Domain.Authentication.Entities;
using Infra.Core.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Authentication.Maps;

public class UsuarioMap : BaseDomainMap<Usuario>
{
    public override void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.Property(x => x.Nome)
               .HasColumnName("Usu_Nome")
               .IsRequired();

        builder.Property(x => x.Email)
               .HasColumnName("Usu_Email")
               .IsRequired();
        
        builder.Property(x => x.Password)
               .HasColumnName("Usu_Password")
               .IsRequired();
        
        builder.ToTable("Usuario", "Authentication");
    }
}