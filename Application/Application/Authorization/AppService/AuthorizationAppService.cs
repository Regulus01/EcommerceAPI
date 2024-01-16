using System.Text.RegularExpressions;
using Application.Interface;
using Application.ViewModels;
using AutoMapper;
using Domain.Authentication.Commands;
using Domain.Authentication.Interface;
using Infra.CrossCutting.Util.Notifications.Implementation;
using Infra.CrossCutting.Util.Notifications.Interface;
using MediatR;

namespace Application.Authorization.AppService;

public class AuthorizationAppService : IAuthorizationAppService
{
    private readonly Notify _notify;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IUsuarioRepository _usuarioRepository;

    public AuthorizationAppService(INotify notify, IMediator mediator, IMapper mapper, IUsuarioRepository usuarioRepository)
    {
        _mediator = mediator;
        _mapper = mapper;
        _usuarioRepository = usuarioRepository;
        _notify = notify.Invoke();
    }
    
    public string ObterToken(LoginViewModel? message)
    {
        if (string.IsNullOrEmpty(message?.Email) || string.IsNullOrEmpty(message.Password))
        {
            _notify.NewNotification("Erro", "É necessário informar o email e senha");
            return null;
        }

        return "sc";
    }

    /// <summary>
    /// Método utilizado para cadastrar um usuário no sistema
    /// </summary>
    /// <remarks>
    ///  Método que cadastrar um usuário no sistema, o usuário cadastrado terá por padrão a role de comprador
    /// </remarks>
    /// <param name="viewModel">Dados necessários para o cadastro do usuário</param>
    public void CadastrarUsuario(CadastroViewModel viewModel)
    {
        if (string.IsNullOrEmpty(viewModel.Email) || string.IsNullOrEmpty(viewModel.Password) 
                                                  || string.IsNullOrEmpty(viewModel.Nome))
        {
            _notify.NewNotification("Erro", "É necessário preencher email, nome e senha");
            return;
        }

        if (!ValidarEmail(viewModel.Email))
        {
            _notify.NewNotification("Erro", "Email invalido");
            return;
        }

        if (_usuarioRepository.EmailCadastrado(viewModel.Email))
        {
            _notify.NewNotification("Erro", "Email já se encontra cadastrado");
            return;
        }
        
        var usuarioCommand = _mapper.Map<CadastrarUsuarioCommand>(viewModel);

        _mediator.Send(usuarioCommand);
    }

    private bool ValidarEmail(string email)
    {
        return Regex.IsMatch(email, "^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$");
    }
}