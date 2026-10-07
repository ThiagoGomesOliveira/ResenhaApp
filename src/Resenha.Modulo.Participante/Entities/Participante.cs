namespace Resenha.Modulo.Participante.Entities;

public class Participante
{
    public long Id { get; set; }
    public long UsuarioCriadorId { get; set; }
    public long UsuarioVinculadoId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string RestricaoAlimentar { get; set; } = string.Empty;


    private Participante() { }

    public static Participante Criar(long usuarioCriadorId, long usuarioVinculadoId, string nome, string telefone, string email, string restricaoAlimentar)
    {
        if (string.IsNullOrEmpty(nome))
            throw new ArgumentNullException(nameof(nome), "Nome é obrigatório.");

        if(usuarioCriadorId <= 0)
            throw new ArgumentException("Necessário informar o ID do usuário criador.", nameof(usuarioCriadorId));

        var participante = new Participante
        {
            UsuarioCriadorId = usuarioCriadorId,
            UsuarioVinculadoId = usuarioVinculadoId,
            Nome = nome,
            Telefone = telefone,
            Email = email,
            RestricaoAlimentar = restricaoAlimentar
        };

        return participante;
    }

    public void AtualizarPerfil(string nome, string telefone, string email, string restricaoAlimentar)
    {
        if (string.IsNullOrEmpty(nome))
            throw new ArgumentNullException(nameof(nome), "Nome é obrigatório.");

        Nome = nome;
        Telefone = telefone;
        Email = email;
        RestricaoAlimentar = restricaoAlimentar;
    }

    public void VincularUsuario(long usuarioVinculadoId)
    {
        if (usuarioVinculadoId <= 0)
            throw new ArgumentException("Necessário informar o ID do usuário vinculado.", nameof(usuarioVinculadoId));

        UsuarioVinculadoId = usuarioVinculadoId;
    }
}
