using FluentValidation;
using NebuloHub.Application.DTOs.Request;

namespace NebuloHub.Application.Validators
{
    public class CreateUsuarioRequestValidator : AbstractValidator<CreateUsuarioRequest>
    {
        public CreateUsuarioRequestValidator()
        {
            RuleFor(u => u.CPF)
                .NotEmpty()
                .WithMessage("CPF é obrigatória.")
                .MinimumLength(11)
                .WithMessage("CPF deve ter no minimo 11 caracteres.");


            RuleFor(u => u.Nome)
                .NotEmpty()
                .WithMessage("O Nome é obrigatório.")
                .MaximumLength(100);

            RuleFor(u => u.Email)
               .NotEmpty()
               .WithMessage("Email é obrigatória.")
               .MaximumLength(255)
               .WithMessage("Email deve ter no máximo 255 caracteres.")
               .Must(s =>
                   s.Any(ch => !char.IsLetterOrDigit(ch)) &&    // Pelo menos um caractere especial
                   s.Length > 11)                                // Maior que 11 caracteres
               .WithMessage("O Email deve conter um caractere especial e ter mais de 11 caracteres.");


            RuleFor(u => u.Senha)
                .NotEmpty()
                .WithMessage("Senha é obrigatória.")
                .MaximumLength(255)
                .WithMessage("Senha deve ter no máximo 255 caracteres.")
                .Must(s =>
                    s.Any(char.IsUpper) &&                       // Pelo menos uma letra maiúscula
                    s.Any(ch => !char.IsLetterOrDigit(ch)) &&    // Pelo menos um caractere especial
                    s.Length > 8)                                // Maior que 8 caracteres
                .WithMessage("Senha deve conter pelo menos uma letra maiúscula, um caractere especial e ter mais de 8 caracteres.");

        }
    }
}
