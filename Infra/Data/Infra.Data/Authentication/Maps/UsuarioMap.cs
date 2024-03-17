using Domain.Administracao.Entities.Pessoa;
using Domain.Authentication.Entities;
using Infra.Core.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Authentication.Maps;

public class UsuarioMap : BaseDomainMap<Usuario>
{
    public override void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.Property(x => x.Email)
               .HasColumnName("Usu_Email")
               .IsRequired();
        
        builder.Property(x => x.Password)
               .HasColumnName("Usu_Password")
               .IsRequired();

        builder.Property(x => x.PessoaId)
               .HasColumnName("Pes_PessoaId");

        builder.HasOne(x => x.Pessoa)
               .WithOne(x => x.Usuario)
               .HasForeignKey<Usuario>(x => x.PessoaId);
        
        builder.ToTable("Usuario", "Authentication");
    }
}