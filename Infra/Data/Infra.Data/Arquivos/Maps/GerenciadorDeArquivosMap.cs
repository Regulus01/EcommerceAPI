using Domain.Arquivos.Entities;
using Infra.Core.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Arquivos.Maps;

public class GerenciadorDeArquivosMap : BaseDomainMap<GerenciadorDeArquivos>
{
    public override void Configure(EntityTypeBuilder<GerenciadorDeArquivos> builder)
    {
        builder.Property(x => x.EntidadeId)
               .HasColumnName("Ger_EntidadeId");

        builder.Property(x => x.Entidade)
               .HasColumnName("Ger_Entidade");
        
        builder.Property(x => x.Caminho)
               .HasColumnName("Ger_Caminho");
        
        builder.Property(x => x.Ordem)
               .HasColumnName("Ger_Ordem");
        
        builder.Property(x => x.ContentType)
               .HasColumnName("Ger_ContentType");
        
        builder.ToTable("GerenciadorDeArquivos", "Arquivos");
    }
}