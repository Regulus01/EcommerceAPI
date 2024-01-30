namespace Domain.Authentication.Entities;

public class Usuario
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public virtual ICollection<UsuarioRole> UsuarioRoles { get; private set; }

    public Usuario(string nome, string email, string password)
    {
        Nome = nome;
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
