using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications
{
    public class EstadoTareaByIdSpecification : Specification<Tarea>
    {
        public EstadoTareaByIdSpecification(int id, bool estado)
        {
            Query.Where(tarea => tarea.Estado == estado && tarea.Id == id);
        }
    }
}
