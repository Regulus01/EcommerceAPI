using Domain.Arquivos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Arquivos.Maps;

public class GerenciadorDeArquivosMap : IEntityTypeConfiguration<GerenciadorDeArquivos>
{
    public void Configure(EntityTypeBuilder<GerenciadorDeArquivos> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Ger_Id")
            .ValueGeneratedOnAdd();

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