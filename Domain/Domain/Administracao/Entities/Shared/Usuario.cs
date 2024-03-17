using Domain.Core.Entity;

namespace Domain.Administracao.Entities.Shared;

public class Usuario : BaseEntity
{
    public string Email { get; private set; }
    public string Password { get; private set; }
    public Guid? PessoaId { get; private set; }
    public virtual Pessoa.Pessoa Pessoa { get; private set; }
}