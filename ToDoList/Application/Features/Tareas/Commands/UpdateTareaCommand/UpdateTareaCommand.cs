using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Tareas.Commands.UpdateTareaCommand
{
    public class UpdateTareaCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int CategoriaId { get; set; }
        public DateTime FechaLimite { get; set; }
        public string Estado { get; set; }
    }

    public class UpdateTareaCommandHandler : IRequestHandler<UpdateTareaCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Tarea> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateTareaCommandHandler(IRepositoryAsync<Tarea> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Response<int>> Handle(UpdateTareaCommand request, CancellationToken cancellationToken)
        {
            var tarea = await _repositoryAsync.GetBySpecAsync(new ActivoTareaByIdSpecification(request.Id, true));
            if (tarea == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }

            tarea.Titulo = request.Titulo;
            tarea.Descripcion = request.Descripcion;
            tarea.CategoriaId = request.CategoriaId;
            tarea.Estado = request.Estado;

            await _repositoryAsync.UpdateAsync(tarea);

            return new Response<int>(tarea.Id);
        }
    }
}
