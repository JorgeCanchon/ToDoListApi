using Application.DTOs;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Tareas.Queries.GetAllTareaById
{
    public class GetTareaByIdQuery : IRequest<Response<TareaDto>>
    {
        public int Id { get; set; }
        public class GetTareaByIdQueryHandler : IRequestHandler<GetTareaByIdQuery, Response<TareaDto>>
        {
            private readonly IRepositoryAsync<Tarea> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetTareaByIdQueryHandler(IRepositoryAsync<Tarea> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<Response<TareaDto>> Handle(GetTareaByIdQuery request, CancellationToken cancellationToken)
            {
                var tarea = await _repositoryAsync.GetBySpecAsync(new ActivoTareaByIdSpecification(request.Id, true));
                if (tarea == null)
                {
                    throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
                }

                var dto = _mapper.Map<TareaDto>(tarea);
                return new Response<TareaDto>(dto);
            }
        }
    }
}
