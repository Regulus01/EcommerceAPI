using Domain.Authentication.Entities;

namespace Domain.Authentication.Interface;

public interface IUsuarioRepository
{
    public bool EmailCadastrado(string email);

    public void AdicionarUsuario(Usuario usuario);
    public void AdicionarRole(UsuarioRole usuarioRole);

    bool Commit();
}