using MediatR;

namespace Domain.Authentication.Commands;

public class CadastrarUsuarioCommand : IRequest
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}