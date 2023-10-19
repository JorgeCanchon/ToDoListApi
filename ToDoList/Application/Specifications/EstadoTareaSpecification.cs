using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications
{
    public class EstadoTareaSpecification : Specification<Tarea>
    {
        public EstadoTareaSpecification(bool estado)
        {
            Query.Where(tarea => tarea.Estado == estado);
        }
    }
}
