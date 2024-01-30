using AutoMapper;
using Domain.Authentication.Commands;
using Domain.Authentication.Configuration;
using Domain.Authentication.Entities;
using Domain.Authentication.Entities.Roles;
using Domain.Interface;
using Infra.CrossCutting.Util.Notifications.Implementation;
using Infra.CrossCutting.Util.Notifications.Interface;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Domain.Authentication.Handle;

public class AuthenticationCommandHandler : IRequestHandler<CadastrarUsuarioCommand>, 
                                            IRequestHandler<LoginCommand, TokenModel>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMapper _mapper;
    private readonly Notify _notify;

    public AuthenticationCommandHandler(IMapper mapper, IUsuarioRepository usuarioRepository,
                                        INotify notify)
    {
        _mapper = mapper;
        _usuarioRepository = usuarioRepository;
        _notify = notify.Invoke();
    }

    public Task Handle(CadastrarUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuario = _mapper.Map<Usuario>(request);
        
        usuario.InformeUsuarioId(Guid.NewGuid());
        usuario.InformeSenha(HashSenha(usuario, request.Password));
        
        _usuarioRepository.Add(usuario);
        
        AtribuirRoleAoUsuario(usuario.Id);
        
        if (!_usuarioRepository.Commit())
        {
            _notify.NewNotification("Erro", "Erro ao inserir dados");
            return Task.FromResult(cancellationToken);
        }

        return Task.CompletedTask;
    }
    
    public Task<TokenModel> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var usuario = _usuarioRepository.ObterUsuario(x => x.Email.Equals(request.Email), 
                                                      query => query.Include(x => x.UsuarioRoles)
                                                                    .ThenInclude(y => y.Role));
        
        if (usuario == null)
        {
            _notify.NewNotification("Erro", "Usuario não encontrado na base de dados");
            return Task.FromResult(new TokenModel());
        }
        
        var passwordHasher = new PasswordHasher<Usuario>();
        
        if (passwordHasher.VerifyHashedPassword(usuario, usuario.Password, request.Password) ==
            PasswordVerificationResult.Failed)
        {
            _notify.NewNotification("Erro", "Senha invalida");
            return Task.FromResult(new TokenModel());
        }

        var token = TokenService.GenerateToken(usuario);

        if (token == null)
        {
            _notify.NewNotification("Erro", "Falha ao obter token de autenticação");
            return Task.FromResult(new TokenModel());
        }

        return Task.FromResult(token);
    }

    private string HashSenha(Usuario usuario, string senha)
    {
        var passwordHasher = new PasswordHasher<Usuario>();
        return passwordHasher.HashPassword(usuario, senha);
    }
    private void AtribuirRoleAoUsuario(Guid usuarioId)
    {
        var usuarioRole = new UsuarioRole(usuarioId, Guid.Parse(RoleRegister.Comprador.Id));;
        _usuarioRepository.Add(usuarioRole);
    }


}