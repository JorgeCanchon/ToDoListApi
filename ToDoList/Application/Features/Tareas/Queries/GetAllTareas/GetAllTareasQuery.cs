using Application.DTOs;
using Application.Features.Tareas.Queries.GetAllTareaById;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Tareas.Queries.GetAllTareas
{
    public class GetAllTareasQuery : IRequest<Response<List<TareaDto>>>
    {
        public class GetAllTareasQueryHandler : IRequestHandler<GetAllTareasQuery, Response<List<TareaDto>>>
        {
            private readonly IRepositoryAsync<Tarea> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetAllTareasQueryHandler(IRepositoryAsync<Tarea> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<Response<List<TareaDto>>> Handle(GetAllTareasQuery request, CancellationToken cancellationToken)
            {
                var tareas = await _repositoryAsync.ListAsync(new EstadoTareaSpecification(true));
                if (!tareas.Any())
                {
                    throw new KeyNotFoundException($"No existen registros para mostrar");
                }

                var dto = _mapper.Map<List<TareaDto>>(tareas);
                return new Response<List<TareaDto>>(dto);
            }
        }
    }
}
