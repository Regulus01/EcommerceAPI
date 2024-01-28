using AutoMapper;
using Domain.Arquivos.Commands;
using Domain.Arquivos.Entities;
using Domain.Arquivos.Interfaces;
using Domain.Arquivos.S3;
using Infra.CrossCutting.Util.Notifications.Implementation;
using Infra.CrossCutting.Util.Notifications.Interface;
using MediatR;

namespace Domain.Arquivos.Handle;

public class GerenciadorDeArquivosCommandHandler : IRequestHandler<GerenciadorDeArquivosCommand> 
{
    private readonly IMapper _mapper;
    private readonly Notify _notify;
    private readonly IGerenciadorDeArquivosRepository _repository;
    private const string UrlBaseFotos = "https://arquivosprojetomarketplace.s3.us-east-2.amazonaws.com";

    public GerenciadorDeArquivosCommandHandler(IMapper mapper, INotify notify, IGerenciadorDeArquivosRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
        _notify = notify.Invoke();
    }

    public async Task Handle(GerenciadorDeArquivosCommand request, CancellationToken cancellationToken)
    {
        var awsS3 = new AmazonS3Service();
        
        var key = $"{Enum.GetName(request.Entidade)}/{request.Ordem}_{request.EntidadeId}";

        var uploadFile = await awsS3.UploadFileAsync("arquivosprojetomarketplace", key, request.Arquivo);

        if (uploadFile)
        {
            var gerenciador = _mapper.Map<GerenciadorDeArquivos>(request);
            
            var caminho = $"{UrlBaseFotos}/{key}";
            
            gerenciador.InformeCaminho(caminho);
            gerenciador.InformeContentType(request.Arquivo.ContentType);
            
            _repository.Add(gerenciador);

            if (_repository.Commit()) 
                return;
            
            _notify.NewNotification("Erro", "Falha ao incluir arquivos no banco de dados");
            return;

        }
        
        _notify.NewNotification("Erro", "Falha ao incluir arquivos no S3");
    }
}