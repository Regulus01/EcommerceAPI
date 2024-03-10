using Domain.Administracao.Entities.Pessoa;
using Infra.Core.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Administracao.Maps;

public class PessoaMap : BaseDomainMap<Pessoa>
{
    public override void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        builder.Property(x => x.Nome)
               .HasColumnName("Pes_Nome");
        
        builder.Property(x => x.Telefone)
            .HasColumnName("Pes_Telefone");
        
        builder.Property(x => x.Cpf)
            .HasColumnName("Pes_Cpf")
            .HasMaxLength(11);

        builder.ToTable("Pessoa", "Administracao");
    }
}