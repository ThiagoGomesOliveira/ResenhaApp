using Resenha.Modulo.Usuario.Validators;

namespace Resenha.Modulo.Usuario.Entities;
public class Usuario
{
    public long Id { get; set; }
    public required string Nome { get; set; }
    public required string Email { get; set; }
    public required string IdentityId { get; set; }
    public required string Telefone { get; set; }
    public DateTime DataCadastro { get; set; }
    public bool Ativo { get; set; }

    private Usuario() { }

    public static Usuario Criar(string nome, string email, string identyId, string telefone)
    {
        var usuario = new Usuario
        {
            Nome = nome,
            Email = email,
            IdentityId = identyId,
            Telefone = telefone,
            DataCadastro = DateTime.Now,
            Ativo = true
        };

        usuario.Validar();

        return usuario;
    }

    private void Validar()
    {
        var validador = new UsuarioValidator();
        var result = validador.Validate(this);

        if (!result.IsValid)
           throw new Exception(string.Join(", ", result.Errors.Select(e => e.ErrorMessage)));
    }

    public void Ativar() => Ativo = true;
    public void Desativar() => Ativo = false;

    public void AtualizarPerfil(string nome, string telefone)
    {
        Nome = nome;
        Telefone = telefone;
        Validar();
    }
}
