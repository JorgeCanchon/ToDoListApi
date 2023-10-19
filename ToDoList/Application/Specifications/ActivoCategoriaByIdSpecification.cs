using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications
{
    public class ActivoCategoriaByIdSpecification : Specification<Categoria>
    {
        public ActivoCategoriaByIdSpecification(int id, bool activo)
        {
            Query.Where(categoria => categoria.Activo == activo && categoria.Id == id);
        }
    }
}
