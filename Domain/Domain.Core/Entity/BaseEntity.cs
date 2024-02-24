namespace Domain.Core.Entity;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTimeOffset CriadoEm { get; set; }
    public DateTimeOffset ModificadoEm { get; set; }
}