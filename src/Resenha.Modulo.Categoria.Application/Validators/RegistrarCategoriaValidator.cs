using FluentValidation;
using Resenha.Modulo.Categoria.Application.DTOs;

namespace Resenha.Modulo.Categoria.Application.Validators;

public class RegistrarCategoriaValidator : AbstractValidator<RegistrarCategoriaDto>
{
    public RegistrarCategoriaValidator()
    {
        RuleFor(p => p.Nome)
            .NotEmpty().WithMessage("O nome é obrigatório.")
            .MaximumLength(400).WithMessage("O nome não pode ter mais de 400 caracteres.");
    }
}
