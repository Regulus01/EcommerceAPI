using Domain.Authentication.Entities;
using Infra.Core.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Authentication.Maps;

public class UsuarioRoleMap : BaseDomainMap<UsuarioRole>
{
    public override void Configure(EntityTypeBuilder<UsuarioRole> builder)
    {
        builder.Property(x => x.UsuarioId)
               .HasColumnName("Usu_UsuarioId");
        
        builder.HasOne(x => x.Usuario)
               .WithMany(x => x.UsuarioRoles)
               .HasForeignKey(x => x.UsuarioId);
           
        builder.Property(x => x.RoleId)
               .HasColumnName("Rol_RoleId");
        
        builder.HasOne(x => x.Role)
               .WithMany(x => x.UsuarioRoles)
               .HasForeignKey(x => x.RoleId);
        
        builder.ToTable("UsuarioRole", "Authentication");
    }
}