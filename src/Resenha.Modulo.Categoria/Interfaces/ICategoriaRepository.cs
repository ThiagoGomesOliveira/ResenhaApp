using Resenha.Modulo.Categoria.Entities;

namespace Resenha.Modulo.Categoria.Interfaces;

public interface ICategoriaRepository
{
    Task AdicionarAsync(Entities.Categoria categoria);

    Task<Entities.Categoria> ObterPorIdAsync(long id);

    Task<bool> SalvarAlteracoesAsync();
}
