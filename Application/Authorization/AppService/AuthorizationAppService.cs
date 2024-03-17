using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using Application.Authorization.ViewModels;
using Application.Interface;
using Application.Shared;
using Application.ViewModels;
using AutoMapper;
using Domain.Authentication.Commands;
using Domain.Interface;
using Infra.CrossCutting.Util.Notifications.Implementation;
using Infra.CrossCutting.Util.Notifications.Interface;
using MediatR;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Application.AppService;

public class AuthorizationAppService : IAuthorizationAppService
{
    private readonly Notify _notify;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IHttpClientFactory _httpClient;

    public AuthorizationAppService(INotify notify, IMediator mediator, IMapper mapper, IUsuarioRepository usuarioRepository, IHttpClientFactory httpClient)
    {
        _mediator = mediator;
        _mapper = mapper;
        _usuarioRepository = usuarioRepository;
        _httpClient = httpClient;
        _notify = notify.Invoke();
    }
    
    public TokenViewModel Login(LoginViewModel? message)
    {
        if (string.IsNullOrEmpty(message?.Email) || string.IsNullOrEmpty(message.Password))
        {
            _notify.NewNotification("Erro", "É necessário informar o email e senha");
            return new TokenViewModel();
        }
        
        if (!ValidarEmail(message.Email))
        {
            _notify.NewNotification("Erro", "Email invalido");
            return new TokenViewModel();
        }
        
        var loginCommand = _mapper.Map<LoginCommand>(message);

        var token = _mediator.Send(loginCommand).Result;

        return _mapper.Map<TokenViewModel>(token);
    }

  
    public async Task CadastrarUsuario(CadastroViewModel viewModel)
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
        
        var usuario = _usuarioRepository.ObterUsuario(x => x.Email.Equals(viewModel.Email));
        
        if (usuario != null)
        {
            _notify.NewNotification("Erro", "Email já se encontra cadastrado");
            return;
        }

        var pessoaId = await CadastrarPessoa(viewModel);

        if (pessoaId == null || pessoaId == Guid.Empty)
        {
            _notify.NewNotification("Erro", "Falha ao cadastrar pessoa");
            return;
        }
        
        var usuarioCommand = _mapper.Map<CadastrarUsuarioCommand>(viewModel);
        usuarioCommand.PessoaId = (Guid) pessoaId;

        await _mediator.Send(usuarioCommand);
    }

    private async Task<Guid?> CadastrarPessoa(CadastrarPessoaViewModel pessoa)
    {
        //Todo - Refatorar para uma classe separada em crosscuting
        var hostPort = Environment.GetEnvironmentVariable("ECOMMERCE_PORT");

        if (string.IsNullOrEmpty(hostPort))
            return null;
        
        var json = new StringContent(
            JsonSerializer.Serialize(pessoa), 
            Encoding.UTF8, 
            MediaTypeNames.Application.Json);
   
        var client = _httpClient.CreateClient(); 
        
        var request = await client.PostAsync($"{hostPort}/api/pessoa", json);
        
        var responseContent = await request.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<CadastrarUsuarioResponse>(responseContent);
        
        return response is { Success: false } ? null : response?.Data;
    }
    private bool ValidarEmail(string email)
    {
        return Regex.IsMatch(email, "^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$");
    }
}