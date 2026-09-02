using Resenha.Modulo.Usuario.Application.DTOs;

namespace Resenha.Modulo.Usuario.Application.Interfaces;

public interface IUsuarioAppService
{
    Task<(bool Sucesso, IEnumerable<string> Erros)> RegistrarAsync(RegistrarUsuarioDto dto);
}
