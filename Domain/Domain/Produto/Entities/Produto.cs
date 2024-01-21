namespace Domain.Authentication.Produto.Entities;

public class Produto
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public decimal Preco { get; private set; }
    public Guid CategoriaId { get; private set; }
    public virtual Categoria Categoria { get; set; }
}