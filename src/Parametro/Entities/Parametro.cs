namespace Parametro.Entities;

public class Parametro
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public int DuracaoPadraoHoras { get; set; }
    public bool Ativo { get; set; }
    public DateTime DataInclusao { get; set; }

    private Parametro() { }

    public void Criar(string nome, string descricao, int duracaoPadraoHoras)
    {
        Nome = nome;
        Descricao = descricao;
        DuracaoPadraoHoras = duracaoPadraoHoras;
        Ativo = true;
        DataInclusao = DateTime.UtcNow;
    }

    public void Atualizar(string nome, string descricao, int duracaoPadraoHoras)
    {
        Nome = nome;
        Descricao = descricao;
        DuracaoPadraoHoras = duracaoPadraoHoras;
    }

    public void Ativar() => Ativo = true;   
    public void Desativar() => Ativo = false;
}


