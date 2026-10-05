using Resenha.Modulo.Evento.Enumerations;

namespace Resenha.Modulo.Evento.Entities;

public class Evento
{
    public long Id { get; set; }
    public long  OrganizadorId { get; set; }
    public long TipoEvendoParametroId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public DateTime DataHorarioInicio { get; set; }
    public DateTime DataHoraFim { get; set; }
    public string Cep { get; set; } = string.Empty;
    public string Logradouro { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public string Bairro { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public int LimiteParticipantes { get; set; }
    public DateTime DataCriacao { get; set; }
    public Status Status { get; set; }

    private Evento() { }

    public void Criar(long organizadorId, long tipoEvendoParametroId, string nome, string descricao, DateTime dataHorarioInicio, DateTime dataHoraFim, string cep, string logradouro, string numero, string bairro, string cidade, string estado, int limiteParticipantes)
    {
        OrganizadorId = organizadorId;
        TipoEvendoParametroId = tipoEvendoParametroId;
        Nome = nome;
        Descricao = descricao;
        DataHorarioInicio = dataHorarioInicio;
        DataHoraFim = dataHoraFim;
        Cep = cep;
        Logradouro = logradouro;
        Numero = numero;
        Bairro = bairro;
        Cidade = cidade;
        Estado = estado;
        LimiteParticipantes = limiteParticipantes;
        DataCriacao = DateTime.UtcNow;
        Status = Status.EmAndamento;
    }

    public void Atualizar(long tipoEvendoParametroId, string nome, string descricao, DateTime dataHorarioInicio, DateTime dataHoraFim, string cep, string logradouro, string numero, string bairro, string cidade, string estado, int limiteParticipantes)
    {
        TipoEvendoParametroId = tipoEvendoParametroId;
        Nome = nome;
        Descricao = descricao;
        DataHorarioInicio = dataHorarioInicio;
        DataHoraFim = dataHoraFim;
        Cep = cep;
        Logradouro = logradouro;
        Numero = numero;
        Bairro = bairro;
        Cidade = cidade;
        Estado = estado;
        LimiteParticipantes = limiteParticipantes;
    }

    public void Cancelar() => Status = Status.Cancelado;

    public void Finalizar() => Status = Status.Finalizdo;

    public void Reabrir() => Status = Status.EmAndamento;

    public int CalcularTotalVagasRestantes(int quantidadeParticipantes)
    {
        return LimiteParticipantes - quantidadeParticipantes;
    }
}
