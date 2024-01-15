using Domain.Authentication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Authentication.Maps;

public class UsuarioRoleMap : IEntityTypeConfiguration<UsuarioRole>
{
    public void Configure(EntityTypeBuilder<UsuarioRole> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("UsR_Id")
            .ValueGeneratedOnAdd();

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