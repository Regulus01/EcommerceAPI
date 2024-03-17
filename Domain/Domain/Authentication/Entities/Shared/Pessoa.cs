using Domain.Core.Entity;

namespace Domain.Authentication.Entities.Shared;

public class Pessoa : BaseEntity
{
    public string Nome { get; private set; }
    public string Cpf { get; private set; }
    public string Telefone { get; private set; }
    public virtual Usuario Usuario { get; private set; }
}