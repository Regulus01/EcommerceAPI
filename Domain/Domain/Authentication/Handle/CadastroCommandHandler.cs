using AutoMapper;
using Domain.Authentication.Commands;
using Domain.Authentication.Entities;
using Domain.Authentication.Entities.Roles;
using Domain.Authentication.Interface;
using Infra.CrossCutting.Util.Notifications.Implementation;
using Infra.CrossCutting.Util.Notifications.Interface;
using MediatR;

namespace Domain.Authentication.Handle;

public class CadastroCommandHandler : IRequestHandler<CadastrarUsuarioCommand>
{
    private readonly IMediator _mediator;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMapper _mapper;
    private readonly Notify _notify;

    public CadastroCommandHandler(IMediator mediator, IMapper mapper, IUsuarioRepository usuarioRepository,
                                  INotify notify)
    {
        _mediator = mediator;
        _mapper = mapper;
        _usuarioRepository = usuarioRepository;
        _notify = notify.Invoke();
    }

    public Task Handle(CadastrarUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuario = _mapper.Map<Usuario>(request);
        
        usuario.InformeUsuarioId(Guid.NewGuid());
        _usuarioRepository.AdicionarUsuario(usuario);
        
        AtribuirRoleAoUsuario(usuario.Id);
        
        if (!_usuarioRepository.Commit())
        {
            _notify.NewNotification("Erro", "Erro ao inserir dados");
            return Task.FromResult(cancellationToken);
        }

        return Task.CompletedTask;
    }

    private void AtribuirRoleAoUsuario(Guid usuarioId)
    {
        var usuarioRole = new UsuarioRole(usuarioId, RoleRegister.Comprador.Id);;
        _usuarioRepository.AdicionarRole(usuarioRole);
    }
}