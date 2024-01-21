namespace Domain.Authentication.Produto.Entities;

public class Categoria
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public virtual ICollection<Produto> Produtos { get; private set; }
}