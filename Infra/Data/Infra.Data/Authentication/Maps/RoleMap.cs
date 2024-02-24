using Domain.Authentication.Entities.Roles;
using Infra.Core.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Authentication.Maps;

public class RoleMap : BaseDomainMap<Role>
{
    public override void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.Property(x => x.Nome)
               .HasColumnName("Rol_Nome");

        builder.ToTable("Role", "Authentication");
    }
}