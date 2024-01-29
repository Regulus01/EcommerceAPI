namespace Domain.Arquivos.Commands.Events;

public class ArquivoIncluidoEvent
{
    public Guid Id { get; set; }
    public string? Caminho { get; set; }

    public ArquivoIncluidoEvent(Guid id, string? caminho)
    {
        Id = id;
        Caminho = caminho;
    }
}