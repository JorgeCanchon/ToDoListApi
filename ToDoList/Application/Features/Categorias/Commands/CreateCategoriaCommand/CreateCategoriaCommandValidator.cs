using FluentValidation;

namespace Application.Features.Categorias.Commands.CreateCategoriaCommand
{
    public class CreateCategoriaCommandValidator : AbstractValidator<CreateCategoriaCommand>
    {
        public CreateCategoriaCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
                .MaximumLength(80).WithMessage("{PropertyName} no debe exceder de {MaxLength}");
        }
    }
}
