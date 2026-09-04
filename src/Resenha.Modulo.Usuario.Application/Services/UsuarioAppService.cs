using Resenha.Modulo.Usuario.Application.DTOs;
using Resenha.Modulo.Usuario.Application.Interfaces;
using Resenha.Modulo.Usuario.Interfaces.Repositories;
using Resenha.Modulo.Usuario.Interfaces.Services;

namespace Resenha.Modulo.Usuario.Application.Services;

public class UsuarioAppService(IUsuarioRepository _usuarioRepository, IAuthService _authService) : IUsuarioAppService
{
    public async Task<(bool Sucesso, IEnumerable<string> Erros)> RegistrarAsync(RegistrarUsuarioDto dto)
    {
        var (sucessoIdentity, identityId, errosIdentity) = await _authService.CriarContaAsync(dto.Email, dto.Senha);

        if (!sucessoIdentity)
            return (false, errosIdentity);

        var usuario =  Entities.Usuario.Criar(dto.Nome, dto.Email, identityId, dto.Telefone);

        await _usuarioRepository.AdicionarAsync(usuario);

        return (true, Enumerable.Empty<string>());
    }
}
