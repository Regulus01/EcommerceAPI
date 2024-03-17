using Domain.Authentication.Entities.Shared;
using Domain.Core.Entity;

namespace Domain.Authentication.Entities;

public class Usuario : BaseEntity
{
    public Guid Id { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public virtual ICollection<UsuarioRole> UsuarioRoles { get; private set; }
    public Guid? PessoaId { get; private set; }

    public virtual Pessoa Pessoa { get; private set; }

    public Usuario(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public void InformeUsuarioId(Guid id)
    {
        Id = id;
    }

    public void InformeSenha(string senha)
    {
        Password = senha;
    }

    public void InformeUsuarioRole(UsuarioRole usuarioRole)
    {
        UsuarioRoles = new List<UsuarioRole> { usuarioRole };
    }
}
