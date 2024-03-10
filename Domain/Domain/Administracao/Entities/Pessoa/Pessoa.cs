using Domain.Core.Entity;

namespace Domain.Administracao.Entities.Pessoa;

public class Pessoa : BaseEntity
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Telefone { get; set; }
}