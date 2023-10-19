using Application.DTOs;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categorias.Queries.GetAllCategoriasById
{
    public class GetCategoriaByIdQuery : IRequest<Response<CategoriaDto>>
    {
        public int Id { get; set; }
        public class GetCategoriaByIdQueryHandler : IRequestHandler<GetCategoriaByIdQuery, Response<CategoriaDto>>
        {
            private readonly IRepositoryAsync<Categoria> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetCategoriaByIdQueryHandler(IRepositoryAsync<Categoria> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<Response<CategoriaDto>> Handle(GetCategoriaByIdQuery request, CancellationToken cancellationToken)
            {
                var categoria = await _repositoryAsync.GetBySpecAsync(new ActivoCategoriaByIdSpecification(request.Id, true));
                if (categoria == null)
                {
                    throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
                }

                var dto = _mapper.Map<CategoriaDto>(categoria);
                return new Response<CategoriaDto>(dto);
            }
        }
    }
}
