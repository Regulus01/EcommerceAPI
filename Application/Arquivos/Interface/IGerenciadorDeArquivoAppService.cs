using Application.Arquivos.ViewModels;

namespace Application.Arquivos.Interface;

public interface IGerenciadorDeArquivoAppService
{
    Task<string?> EnviarArquivoS3(EnviarGerenciadorDeArquivoViewModel entidade);
}