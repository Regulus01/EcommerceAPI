using MediatR;

namespace Domain.Administracao.Commands.Pessoa;

public class CadastrarPessoaCommand : IRequest
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Telefone { get; set; }
}