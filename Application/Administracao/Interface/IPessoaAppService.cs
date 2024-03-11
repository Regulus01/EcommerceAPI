using Application.Administracao.ViewModels;

namespace Application.Administracao.Interface;

public interface IPessoaAppService
{
    Guid CadastrarPessoa(CadastrarPessoaViewModel viewModel);
}