using FluentValidation;

namespace Application.Features.Tareas.Commands.UpdateTareaCommand
{
    public class UpdateTareaCommandValidator : AbstractValidator<UpdateTareaCommand>
    {
        public UpdateTareaCommandValidator()
        {
            RuleFor(p => p.Id)
               .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
               .GreaterThan(0).WithMessage("{PropertyName} debe ser numerico mayor a 0.");

            RuleFor(p => p.Titulo)
               .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
               .MaximumLength(100).WithMessage("{PropertyName} no debe exceder de {MaxLength}");

            RuleFor(p => p.Descripcion)
            .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
            .MaximumLength(300).WithMessage("{PropertyName} no debe exceder de {MaxLength}");

            RuleFor(p => p.FechaLimite)
           .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.");

            RuleFor(p => p.CategoriaId)
              .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
              .GreaterThan(0).WithMessage("{PropertyName} debe ser numerico mayor a 0.");
        }
    }
}
