using FluentValidation;

namespace Application.Features.Categorias.Commands.UpdateCategoriaCommand
{
    public class UpdateCategoriaCommandValidator : AbstractValidator<UpdateCategoriaCommand>
    {
        public UpdateCategoriaCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
                .GreaterThan(0).WithMessage("{PropertyName} debe ser numerico mayor a 0.");

            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
                .MaximumLength(80).WithMessage("{PropertyName} no debe exceder de {MaxLength}");
        }
    }
}
