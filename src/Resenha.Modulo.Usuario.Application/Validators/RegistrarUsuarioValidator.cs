using FluentValidation;
using Resenha.Modulo.Usuario.Application.DTOs;

namespace Resenha.Modulo.Usuario.Application.Validators;

public class RegistrarUsuarioValidator : AbstractValidator<RegistrarUsuarioDto>
{
    public RegistrarUsuarioValidator()
    {
        RuleFor(p => p.Nome)
            .NotEmpty().WithMessage("O nome é obrigatório.")
            .MaximumLength(300).WithMessage("O nome não pode ter mais de 300 caracteres.");
        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("O email é obrigatório.")
            .EmailAddress().WithMessage("O email deve ser válido.")
            .MaximumLength(300).WithMessage("O email não pode ter mais de 300 caracteres.");
        RuleFor(p => p.Senha)
            .NotEmpty().WithMessage("A senha é obrigatória.")
            .MinimumLength(6).WithMessage("A senha deve ter no mínimo 6 caracteres.")
            .MaximumLength(100).WithMessage("A senha não pode ter mais de 100 caracteres.");
        RuleFor(p => p.Telefone)
            .MaximumLength(15).WithMessage("O telefone não pode ter mais de 15 caracteres.");
    }
}
