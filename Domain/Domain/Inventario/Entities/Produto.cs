using Domain.Core.Entity;

namespace Domain.Inventario.Entities;

public class Produto : BaseEntity
{
    public string Nome { get; private set; }
    public decimal Preco { get; private set; }
    public int? Estoque { get; private set; }
    public string CaminhoFotoDeCapa { get; private set; }
    public int Visualizacoes { get; private set; }
    public Guid CategoriaId { get; private set; }
    public virtual Categoria Categoria { get; set; }

    public void InformeCaminhoFotoDeCapa(string caminho)
    {
        CaminhoFotoDeCapa = caminho;
    }
    
}