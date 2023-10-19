using FluentValidation;

namespace Application.Features.Categorias.Commands.DeleteCategoriaCommand
{
    public class DeleteCategoriaCommandValidator : AbstractValidator<DeleteCategoriaCommand>
    {
        public DeleteCategoriaCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
                .GreaterThan(0).WithMessage("{PropertyName} debe ser numerico mayor a 0.");
        }
    }
}
