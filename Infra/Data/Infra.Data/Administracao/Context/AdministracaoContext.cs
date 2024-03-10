using Domain.Administracao.Entities.Pessoa;
using Infra.Data.Administracao.Maps;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Administracao.Context;

public class AdministracaoContext : DbContext
{
    public DbSet<Pessoa> Pessoas { get; set; }
    
    public AdministracaoContext()
    {
    }
    
    public AdministracaoContext(DbContextOptions<AdministracaoContext> builderOptions) : base(builderOptions)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new PessoaMap());
    }
}