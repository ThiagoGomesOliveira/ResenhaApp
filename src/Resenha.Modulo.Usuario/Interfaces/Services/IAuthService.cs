namespace Resenha.Modulo.Usuario.Interfaces.Services;

public interface IAuthService
{
    /// <summary>
    ///  Cria o usuário no ASP.NET Core Identity   
    /// </summary>
    /// <param name="email"></param>
    /// <param name="senha"></param>
    /// <returns>Retorna se teve sucesso, o IdentityId gerado (FK) e uma lista de erros caso falhe.</returns>
    Task<(bool Sucesso, string IdentityId, IEnumerable<string> Erros)> CriarContaAsync(string email, string senha);
    /// <summary>
    /// Realiza a autenticação/login do usuário.
    /// </summary>
    Task<bool> AutenticarAsync(string email, string senha);
    /// <summary>
    /// Encerra a sessão do usuário logado.
    /// </summary>
    Task DeslogarAsync();
}
