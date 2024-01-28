namespace Domain.Arquivos.Entities;

public class GerenciadorDeArquivos
{
    public Guid Id { get; private set; }
    public Guid EntidadeId { get; private set; }
    public string Entidade { get; private set; }
    public string Caminho { get; private set; }
    public int Ordem { get; private set; }
    public string ContentType { get; private set; }


    public void InformeContentType(string contentType)
    {
        ContentType = contentType;
    }
    
    public void InformeCaminho(string caminho)
    {
        Caminho = caminho;
    }
}