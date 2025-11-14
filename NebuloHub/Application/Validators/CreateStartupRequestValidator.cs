using FluentValidation;
using NebuloHub.Application.DTOs.Request;

namespace NebuloHub.Application.Validators
{
    public class CreateStartupRequestValidator : AbstractValidator<CreateStartupRequest>
    {
        public CreateStartupRequestValidator()
        {
            RuleFor(u => u.CNPJ)
                .NotEmpty()
                .WithMessage("CNPJ é obrigatória.")
                .MinimumLength(14)
                .WithMessage("CNPJ deve ter no minimo 11 caracteres.");


            RuleFor(u => u.NomeStartup)
                .NotEmpty()
                .WithMessage("O Nome é obrigatório.")
                .MaximumLength(100);

            RuleFor(u => u.EmailStartup)
               .NotEmpty()
               .WithMessage("Email é obrigatória.")
               .MaximumLength(255)
               .WithMessage("Senha deve ter no máximo 255 caracteres.")
               .Must(s =>
                   s.Any(ch => !char.IsLetterOrDigit(ch)) &&    // Pelo menos um caractere especial
                   s.Length > 11)                                // Maior que 11 caracteres
               .WithMessage("O Email deve conter um caractere especial e ter mais de 11 caracteres.");


        }
    }
}
