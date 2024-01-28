using Application.Arquivos.Interface;
using Application.Arquivos.ViewModels;
using AutoMapper;
using Domain.Arquivos.Commands;
using Infra.CrossCutting.Util.Notifications.Implementation;
using Infra.CrossCutting.Util.Notifications.Interface;
using MediatR;

namespace Application.Arquivos.AppService;

public class GerenciadorDeArquivosAppService : IGerenciadorDeArquivoAppService
{
    private readonly Notify _notify;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public GerenciadorDeArquivosAppService(INotify notify, IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
        //_usuarioRepository = usuarioRepository;
        _notify = notify.Invoke();
    }
    public async Task EnviarArquivoS3(EnviarGerenciadorDeArquivoViewModel entidade)
    {
        var command = _mapper.Map<GerenciadorDeArquivosCommand>(entidade);
        
        await _mediator.Send(command);
    }
}