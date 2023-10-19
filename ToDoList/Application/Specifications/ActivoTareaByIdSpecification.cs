using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications
{
    public class ActivoTareaByIdSpecification : Specification<Tarea>
    {
        public ActivoTareaByIdSpecification(int id, bool activo)
        {
            Query.Where(tarea => tarea.Activo == activo && tarea.Id == id);
        }
    }
}
