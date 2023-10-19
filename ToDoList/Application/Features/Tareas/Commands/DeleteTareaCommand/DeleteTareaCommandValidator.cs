using FluentValidation;

namespace Application.Features.Tareas.Commands.DeleteTareaCommand
{
    public class DeleteTareaCommandValidator : AbstractValidator<DeleteTareaCommand>
    {
        public DeleteTareaCommandValidator()
        {
            RuleFor(p => p.Id)
               .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
               .GreaterThan(0).WithMessage("{PropertyName} debe ser numerico mayor a 0.");
        }
    }
}
