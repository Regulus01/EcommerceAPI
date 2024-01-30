using Domain.Authentication.Configuration;
using MediatR;

namespace Domain.Authentication.Commands;

public class LoginCommand: IRequest<TokenModel>
{
    public string Email { get; set; }
    public string Password { get; set; }
}