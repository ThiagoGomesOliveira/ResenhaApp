
namespace Resenha.Modulo.Usuario.Entities;
public class Usuario
{
    public long Id { get; private set; }
    public string Nome { get; private set; }
    public  string Email { get; private set; }
    public string IdentityId { get; private set; }
    public string  Telefone { get; private set; }
    public DateTime DataCadastro { get; private set; }
    public bool Ativo { get; private set; }

    private Usuario() { }

    public static Usuario Criar(string nome, string email, string identityId, string telefone)
    {
        if (string.IsNullOrEmpty(email))
            throw new ArgumentNullException(nameof(email), "Email obrigatório");

        if (string.IsNullOrEmpty(identityId))
            throw new ArgumentNullException(nameof(identityId), "IdentityId é obrigatório.");

        if (string.IsNullOrEmpty(nome))
            throw new ArgumentNullException(nameof(nome), "Nome é obrigatório.");

        var usuario = new Usuario
        {
            Nome = nome,
            Email = email,
            IdentityId = identityId,
            Telefone = telefone,
            DataCadastro = DateTime.UtcNow,
            Ativo = true
        };

        return usuario;
    }

    public void Ativar() => Ativo = true;
    public void Desativar() => Ativo = false;

    public void AtualizarPerfil(string nome, string telefone)
    {
        Nome = nome;
        Telefone = telefone;
    }
}
