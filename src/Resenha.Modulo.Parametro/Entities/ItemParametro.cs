using Resenha.Modulo.Parametro.Enumerations;

namespace Resenha.Modulo.Parametro.Entities;

public class ItemParametro
{
    public long Id { get; set; }
    public long ParametroId { get; set; }
    public long CategoriaId { get; set; }
    public decimal QuantidadePorPessoa { get; set; }
    public UnidadeMedida UnidadeMedida { get; set; }
}
