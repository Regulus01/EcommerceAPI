namespace Domain.Authentication.Entities.Roles;

public class Role
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }

    public Role(Guid id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}