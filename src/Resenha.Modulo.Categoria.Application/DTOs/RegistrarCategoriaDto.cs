namespace Resenha.Modulo.Categoria.Application.DTOs;
public class RegistrarCategoriaDto
{
    public required string Nome { get; init; }
    public string Descricao { get; init; } = string.Empty;
    public string Icone { get; init; } = string.Empty;
}
