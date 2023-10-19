using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications
{
    public class ActivoCategoriaSpecification : Specification<Categoria>
    {
        public ActivoCategoriaSpecification(bool activo)
        {
            Query.Where(categoria => categoria.Activo == activo);
        }
    }
}
