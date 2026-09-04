using Resenha.Infrastructure.Persistence;
using Resenha.Modulo.Usuario.Interfaces.Repositories;

namespace Resenha.Infrastructure.Repositories.Usuario;

public class UsuarioRepository(ResenhaDbContext _context) : IUsuarioRepository
{
    public async Task AdicionarAsync(Modulo.Usuario.Entities.Usuario usuario)
    {
        await  _context.Usuarios.AddAsync(usuario);
    }

    public async Task AtualizarAsync(Modulo.Usuario.Entities.Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
        await Task.CompletedTask;
    }

    public async Task<Modulo.Usuario.Entities.Usuario> ObterPorIdAsync(long id)
    {
        return await _context.Usuarios.FindAsync(id);
    }

    public async Task<bool> SalvarAlteracoesAsync()
    {
       return await _context.SaveChangesAsync() > 0;
    }
}
