using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels;

public class CadastroViewModel : CadastrarPessoaViewModel
{

    [Required(ErrorMessage = "É necessário informar o email")]
    public string Email { get; set; }
    [Required(ErrorMessage = "É necessário informar a senha")]
    public string Password { get; set; }
}

public class CadastrarPessoaViewModel {
    
    [Required(ErrorMessage = "É necessário informar o nome")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "É necessário informar o cpf")]
    public string Cpf { get; set; }
    [Required(ErrorMessage = "É necessário fornecer um numero para contato")]
    public string Telefone { get; set; }
}