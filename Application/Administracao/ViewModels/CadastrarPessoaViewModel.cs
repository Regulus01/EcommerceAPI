using System.ComponentModel.DataAnnotations;

namespace Application.Administracao.ViewModels;

public class CadastrarPessoaViewModel
{
    /// <summary>
    /// Nome da pessoa
    /// </summary>
    [Required]
    public string Nome { get; set; }
    
    /// <summary>
    /// Cpf da pessoa
    /// </summary>
    [Required]
    public string Cpf { get; set; }
    
    /// <summary>
    /// Telefone da pessoa
    /// </summary>
    [Required]
    public string Telefone { get; set; }
}