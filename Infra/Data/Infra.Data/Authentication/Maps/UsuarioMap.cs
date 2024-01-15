using Domain.Authentication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Authentication.Maps;

public class UsuarioMap : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnName("Usu_Id")
            .ValueGeneratedOnAdd();

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