using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications
{
    public class EstadoCategoriaSpecification : Specification<Categoria>
    {
        public EstadoCategoriaSpecification(bool estado)
        {
            Query.Where(categoria => categoria.Estado == estado);
        }
    }
}
