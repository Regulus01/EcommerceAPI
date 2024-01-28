using Domain.Arquivos.Entities;
using Infra.Data.Arquivos.Maps;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Arquivos.Context;

public class GerenciadorDeArquivosContext : DbContext
{
    public DbSet<GerenciadorDeArquivos> Arquivos { get; set; }

    
    public GerenciadorDeArquivosContext()
    {
    }
    
    public GerenciadorDeArquivosContext(DbContextOptions<GerenciadorDeArquivosContext> builderOptions) : base(builderOptions)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new GerenciadorDeArquivosMap());
    }
}