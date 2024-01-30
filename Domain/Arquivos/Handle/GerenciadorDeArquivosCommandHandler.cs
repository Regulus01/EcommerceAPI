﻿using Amazon.S3;
using Amazon.S3.Transfer;
using AutoMapper;
using Domain.Arquivos.Commands;
using Domain.Arquivos.Commands.Events;
using Domain.Arquivos.Entities;
using Domain.Arquivos.Interfaces;
using Infra.CrossCutting.Util.Notifications.Implementation;
using Infra.CrossCutting.Util.Notifications.Interface;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Domain.Arquivos.Handle;

public class GerenciadorDeArquivosCommandHandler : IRequestHandler<GerenciadorDeArquivosCommand, ArquivoIncluidoEvent?> 
{
    private readonly IMapper _mapper;
    private readonly Notify _notify;
    private readonly IGerenciadorDeArquivosRepository _repository;
    private readonly IAmazonS3 _amazonS3;
    private const string UrlBaseFotos = "https://arquivosprojetomarketplace.s3.us-east-2.amazonaws.com";

    public GerenciadorDeArquivosCommandHandler(IMapper mapper, INotify notify, IGerenciadorDeArquivosRepository repository, IAmazonS3 amazonS3)
    {
        _mapper = mapper;
        _repository = repository;
        _amazonS3 = amazonS3;
        _notify = notify.Invoke();
    }

    public async Task<ArquivoIncluidoEvent?> Handle(GerenciadorDeArquivosCommand request, CancellationToken cancellationToken)
    {
        var key = $"{Enum.GetName(request.Entidade)}/{request.Ordem}_{request.EntidadeId}";

        var uploadFile = await UploadFileAsync("arquivosprojetomarketplace", key, request.Arquivo);

        if (uploadFile)
        {
            var gerenciador = _mapper.Map<GerenciadorDeArquivos>(request);
            
            var caminho = $"{UrlBaseFotos}/{key}";
            
            gerenciador.InformeCaminho(caminho);
            gerenciador.InformeContentType(request.Arquivo.ContentType);

            var arquivo = _repository.ObterArquivo(x => x.Ordem == request.Ordem);
            
            //Caso exista um arquivo com a mesma ordem, ele será deletado e o novo ficará no lugar
            if (arquivo != null)
                _repository.Delete(arquivo);
            
            _repository.Add(gerenciador);

            if (_repository.Commit()) 
                return new ArquivoIncluidoEvent(gerenciador.Id, caminho);
            
            _notify.NewNotification("Erro", "Falha ao incluir arquivos no banco de dados");
            return null;
        }
        
        _notify.NewNotification("Erro", "Falha ao incluir arquivos no S3");
        return null;
    }
    
    private async Task<bool> UploadFileAsync(string bucket, string key, IFormFile file)
    {
        using var memoryStream = new MemoryStream();
        await file.CopyToAsync(memoryStream);

        var fileTransferUtility = new TransferUtility(_amazonS3);

        await fileTransferUtility.UploadAsync(new TransferUtilityUploadRequest
        {
            InputStream = memoryStream,
            Key = key,
            BucketName = bucket,
            ContentType = file.ContentType
        });

        return true;
    }
}