using Domain.Authentication.Entities.Roles;
using Domain.Core.Entity;

namespace Domain.Authentication.Entities;

public class UsuarioRole : BaseEntity
{
    public Guid UsuarioId { get; private set; }
    public virtual Usuario Usuario { get; private set; }
    public Guid RoleId { get; private set; }
    public virtual Role Role { get; private set; }

    public UsuarioRole() { }
    public UsuarioRole(Guid usuarioId, Guid roleId)
    {
        UsuarioId = usuarioId;
        RoleId = roleId;
    }
}