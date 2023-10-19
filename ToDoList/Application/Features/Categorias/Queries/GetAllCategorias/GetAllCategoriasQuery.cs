using Application.DTOs;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categorias.Queries.GetAllCategorias
{
    public class GetAllCategoriasQuery : IRequest<Response<List<CategoriaDto>>>
    {
        public class GetAllCategoriasQueryHandler : IRequestHandler<GetAllCategoriasQuery, Response<List<CategoriaDto>>>
        {
            private readonly IRepositoryAsync<Categoria> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetAllCategoriasQueryHandler(IRepositoryAsync<Categoria> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<Response<List<CategoriaDto>>> Handle(GetAllCategoriasQuery request, CancellationToken cancellationToken)
            {
                var categorias = await _repositoryAsync.ListAsync(new EstadoCategoriaSpecification(true));
                if (!categorias.Any())
                {
                    throw new KeyNotFoundException($"No existen registros para mostrar");
                }

                var dto = _mapper.Map<List<CategoriaDto>>(categorias);
                return new Response<List<CategoriaDto>>(dto);
            }
        }
    }
}
