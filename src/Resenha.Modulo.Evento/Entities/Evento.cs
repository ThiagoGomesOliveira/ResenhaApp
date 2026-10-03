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

}
