using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications
{
    public class ActivoTareaSpecification : Specification<Tarea>
    {
        public ActivoTareaSpecification(bool activo)
        {
            Query.Where(tarea => tarea.Activo == activo);
        }
    }
}
