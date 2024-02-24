using Domain.Core.Entity;

namespace Domain.Authentication.Entities.Roles;

public class Role : BaseEntity
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public virtual ICollection<UsuarioRole> UsuarioRoles { get; private set; }

    public Role(Guid id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}