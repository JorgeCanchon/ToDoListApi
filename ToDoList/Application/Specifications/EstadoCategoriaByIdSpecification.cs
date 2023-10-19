using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications
{
    public class EstadoCategoriaByIdSpecification : Specification<Categoria>
    {
        public EstadoCategoriaByIdSpecification(int id, bool estado)
        {
            Query.Where(categoria => categoria.Estado == estado && categoria.Id == id);
        }
    }
}
