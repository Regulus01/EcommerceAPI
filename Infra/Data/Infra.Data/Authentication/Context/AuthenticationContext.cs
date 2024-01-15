using Domain.Authentication.Entities;
using Domain.Authentication.Entities.Roles;
using Infra.Data.Authentication.Maps;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Authentication.Context;

public class AuthenticationContext : DbContext
{
    public DbSet<Usuario> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    
    public AuthenticationContext()
    {
    }
    
    public AuthenticationContext(DbContextOptions<AuthenticationContext> builderOptions) : base(builderOptions)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UsuarioMap());
        modelBuilder.ApplyConfiguration(new RoleMap());
        modelBuilder.ApplyConfiguration(new UsuarioRoleMap());
    }
}