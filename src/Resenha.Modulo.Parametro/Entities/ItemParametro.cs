using Resenha.Modulo.Parametro.Enumerations;

namespace Resenha.Modulo.Parametro.Entities;

public class ItemParametro
{
    public long Id { get; set; }
    public long ParametroId { get; set; }
    public long CategoriaId { get; set; }
    public decimal QuantidadePorPessoa { get; set; }
    public UnidadeMedida UnidadeMedida { get; set; }

    private ItemParametro() { }

    public static ItemParametro Criar(long parametroId, long categoriaId, decimal quantidadePorPessoa, UnidadeMedida unidadeMedida)
    {
        if (parametroId <= 0)
            throw new ArgumentException("Necessário informar o parâmetro.", nameof(parametroId));

        if (categoriaId <= 0)
            throw new ArgumentException("Necessário informar a categoria.", nameof(categoriaId));

        if (quantidadePorPessoa <= decimal.Zero)
            throw new ArgumentException("Quantidade Por Pessoa deve ser maior que zero.", nameof(quantidadePorPessoa));

        if (!Enum.IsDefined(unidadeMedida))
            throw new ArgumentException("Unidade de Medida inválida.", nameof(unidadeMedida));

        var itemParametro = new ItemParametro
        {
            ParametroId = parametroId,
            CategoriaId = categoriaId,
            QuantidadePorPessoa = quantidadePorPessoa,
            UnidadeMedida = unidadeMedida
        };

        return itemParametro;
    }

    public void Atualizar(long parametroId, long categoriaId, decimal quantidadePorPessoa, UnidadeMedida unidadeMedida)
    {
        if (parametroId <= 0)
            throw new ArgumentException("Necessário informar o parâmetro.", nameof(parametroId));

        if (categoriaId <= 0)
            throw new ArgumentException("Necessário informar a categoria.", nameof(categoriaId));

        if (quantidadePorPessoa <= decimal.Zero)
            throw new ArgumentException("Quantidade Por Pessoa deve ser maior que zero.", nameof(quantidadePorPessoa));

        if (!Enum.IsDefined(unidadeMedida))
            throw new ArgumentException("Unidade de Medida inválida.", nameof(unidadeMedida));

        ParametroId = parametroId;
        CategoriaId = categoriaId;
        QuantidadePorPessoa = quantidadePorPessoa;
        UnidadeMedida = unidadeMedida;
    }

}
