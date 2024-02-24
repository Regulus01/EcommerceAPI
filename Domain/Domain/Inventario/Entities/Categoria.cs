using Domain.Core.Entity;

namespace Domain.Inventario.Entities;

public class Categoria : BaseEntity
{
    public string Nome { get; private set; }
    public virtual ICollection<Produto> Produtos { get; private set; }
}