using Application.Arquivos.ViewModels;
using Domain.Arquivos.Entities;

namespace Application.Arquivos.Interface;

public interface IGerenciadorDeArquivoAppService
{
    Task<string?> EnviarArquivoS3(EnviarGerenciadorDeArquivoViewModel entidade);
    Task DeletarArquivo(Guid id);
    IEnumerable<GetGerenciadorDeArquivosViewModel> ObterArquivos(Guid entidadeId);
}