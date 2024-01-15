using Domain.Authentication.Entities.Roles;

namespace Domain.Authentication.Entities;

public class Usuario
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public virtual IEnumerable<UsuarioRole> UsuarioRoles { get; private set; }
    
    public Usuario(string nome, string email, string password)
    {
        Nome = nome;
        Email = email;
        Password = password;
    }
}