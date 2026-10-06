namespace Resenha.Modulo.Categoria.Entities;

public class Categoria
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Icone { get; set; } = string.Empty;

    private Categoria() { }

    public static Categoria Criar(string nome, string descricao, string icone)
    {
        if (string.IsNullOrEmpty(nome))
            throw new ArgumentNullException(nameof(nome), "Nome é obrigatório.");

        var categoria = new Categoria
        {
            Nome = nome,
            Descricao = descricao,
            Icone = icone
        };

        return categoria;
    }   

    public void Atualizar(string nome, string descricao, string icone)
    {
        if (string.IsNullOrEmpty(nome))
            throw new ArgumentNullException(nameof(nome), "Nome é obrigatório.");   

        Nome = nome;
        Descricao = descricao;
        Icone = icone;
    }
}
