using Infra.Data.Inventario.Maps;
using Microsoft.EntityFrameworkCore;
using ProdutoDomain = Domain.Authentication.Inventario.Entities.Produto;

namespace Infra.Data.Inventario.Context;

public class InventarioContext : DbContext
{
    public DbSet<ProdutoDomain> Produtos { get; set; }
    
    public InventarioContext()
    {
    }
    
    public InventarioContext(DbContextOptions<InventarioContext> builderOptions) : base(builderOptions)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ProdutoMap());
        modelBuilder.ApplyConfiguration(new CategoriaMap());
    }
}