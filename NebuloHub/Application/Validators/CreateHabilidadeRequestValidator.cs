using FluentValidation;
using NebuloHub.Application.DTOs.Request;

namespace NebuloHub.Application.Validators
{
    public class CreateHabilidadeRequestValidator : AbstractValidator<CreateHabilidadeRequest>
    {
        public CreateHabilidadeRequestValidator()
        {

            RuleFor(u => u.NomeHabilidade)
                .NotEmpty()
                .WithMessage("O Nome é obrigatório.")
                .MaximumLength(250);

            RuleFor(u => u.TipoHabilidade)
                .NotEmpty()
                .WithMessage("O Nome é obrigatório.")
                .MaximumLength(100);


        }
    }
}
