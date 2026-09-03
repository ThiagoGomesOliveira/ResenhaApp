using FluentValidation;

namespace Resenha.Modulo.Usuario.Validators;
public class UsuarioValidator : AbstractValidator<Entities.Usuario>
{
    public UsuarioValidator()
    {
        RuleFor(p => p.Nome)
            .NotEmpty().WithMessage("O nome é obrigatório.")
            .MaximumLength(300).WithMessage("O nome não pode ter mais de 300 caracteres.");

        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("O email é obrigatório.")
            .EmailAddress().WithMessage("O email deve ser válido.")
            .MaximumLength(300).WithMessage("O email não pode ter mais de 300 caracteres.");

        RuleFor(p => p.IdentityId)
            .NotEmpty().WithMessage("O IdentityId é obrigatório.");

        RuleFor(p => p.Telefone)
            .NotEmpty().WithMessage("O telefone é obrigatório.")
            .MaximumLength(15).WithMessage("O telefone não pode ter mais de 15 caracteres.");
    }
}
