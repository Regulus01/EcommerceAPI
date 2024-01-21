using Infra.Data.Authentication.Context;
using Infra.Data.Authentication.Maps;
using Infra.Data.Produto.Maps;
using Microsoft.EntityFrameworkCore;
using ProdutoDomain = Domain.Authentication.Produto.Entities.Produto;

namespace Infra.Data.Produto.Context;

public class ProdutoContext : DbContext
{
    public DbSet<ProdutoDomain> Produtos { get; set; }
    
    public ProdutoContext()
    {
    }
    
    public ProdutoContext(DbContextOptions<ProdutoContext> builderOptions) : base(builderOptions)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ProdutoMap());
    }
}