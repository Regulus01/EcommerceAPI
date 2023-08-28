using Domain.Authentication.Entities.Roles;

namespace Domain.Authentication.Entities;

public class Usuario
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public Guid RoleId { get; private set; }
    public virtual Role Role { get; private set; }


    public Usuario(Guid id, string name, string email, string password)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
    }
}