using MediatR;

namespace Domain.Authentication.Commands;

public class CadastrarUsuarioCommand : IRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public Guid PessoaId { get; set; }
}