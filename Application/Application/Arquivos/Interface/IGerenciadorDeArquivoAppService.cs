using Application.Arquivos.ViewModels;

namespace Application.Arquivos.Interface;

public interface IGerenciadorDeArquivoAppService
{
    Task EnviarArquivoS3(EnviarGerenciadorDeArquivoViewModel entidade);
}