namespace Resenha.Modulo.Usuario.Application.DTOs;

public record RegistrarUsuarioDto(
    string Nome,
    string Email,
    string Telefone,
    string Senha);
