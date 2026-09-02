namespace Resenha.Modulo.Usuario.Interfaces.Repositories;

public interface IUsuarioRepositorycs
{
    Task<Entities.Usuario> ObterPorIdAsync(long id);
    Task AtualizarAsync(Entities.Usuario usuario);
    Task<bool> SalvarAlteracoesAsync();
    Task AdicionarAsync(Entities.Usuario usuario);
}
