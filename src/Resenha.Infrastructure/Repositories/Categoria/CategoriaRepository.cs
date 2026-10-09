using Resenha.Infrastructure.Persistence;
using Resenha.Modulo.Categoria.Interfaces;

namespace Resenha.Infrastructure.Repositories.Categoria;

public class CategoriaRepository(ResenhaDbContext _resenhaDbContext) : ICategoriaRepository
{
    public async Task AdicionarAsync(Modulo.Categoria.Entities.Categoria categoria)
    {
        await _resenhaDbContext.Categorias.AddAsync(categoria);
    }

    public async Task<Modulo.Categoria.Entities.Categoria> ObterPorIdAsync(long id)
    {
        return await _resenhaDbContext.Categorias.FindAsync(id);
    }

    public async Task<bool> SalvarAlteracoesAsync()
    {
        await _resenhaDbContext.SaveChangesAsync();
        return true;
    }
}
