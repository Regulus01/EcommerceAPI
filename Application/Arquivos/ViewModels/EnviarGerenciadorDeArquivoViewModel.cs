using Enums.Enums;

namespace Application.Arquivos.ViewModels;

public class EnviarGerenciadorDeArquivoViewModel
{
    public Guid EntidadeId { get; set; }
    public Tabela Entidade { get; set; }
    public int Ordem { get; set; }
    public IFormFile Arquivo { get; set; }
}