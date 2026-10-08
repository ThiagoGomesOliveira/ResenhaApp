using Resenha.Modulo.Participante.Enumerations;

namespace Resenha.Modulo.Participante.Entities;

public class ParticipanteEvento
{
    public  long Id { get; set; }
    public long EventoId { get; set; }
    public long ParticipanteId { get; set; }
    public StatusPresenca StatusPresenca { get; set; }
    public string ItemAComprarTrazer { get; set; } = string.Empty;
    public bool Pago { get; set; }
    public DateTime DataConfirmacao { get; set; }

    private ParticipanteEvento() { }

    public static ParticipanteEvento Criar(long eventoId, long participanteId, StatusPresenca statusPresenca, string itemAComprarTrazer)
    {
        if (eventoId <= 0)
            throw new ArgumentException("Necessário informar o ID do evento.", nameof(eventoId));

        if (participanteId <= 0)
            throw new ArgumentException("Necessário informar o ID do participante.", nameof(participanteId));

        var participanteEvento = new ParticipanteEvento
        {
            EventoId = eventoId,
            ParticipanteId = participanteId,
            StatusPresenca = statusPresenca,
            ItemAComprarTrazer = itemAComprarTrazer,
        };
        return participanteEvento;
    }

    public void AtualizarStatusPresenca(StatusPresenca statusPresenca)
    {
        StatusPresenca = statusPresenca;

        if(statusPresenca == StatusPresenca.Confirmado)
        {
            DataConfirmacao = DateTime.UtcNow;
        }
    }
   
    public void MarcarPago()
    {
        Pago = true;
    }
}
