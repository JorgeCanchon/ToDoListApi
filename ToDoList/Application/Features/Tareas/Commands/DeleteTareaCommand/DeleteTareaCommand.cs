using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Tareas.Commands.DeleteTareaCommand
{
    public class DeleteTareaCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteTareaCommandHandler : IRequestHandler<DeleteTareaCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Tarea> _repositoryAsync;

        public DeleteTareaCommandHandler(IRepositoryAsync<Tarea> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
        }

        public async Task<Response<int>> Handle(DeleteTareaCommand request, CancellationToken cancellationToken)
        {
            var tarea = await _repositoryAsync.GetBySpecAsync(new ActivoTareaByIdSpecification(request.Id, true));
            if (tarea == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }

            tarea.Activo = false;

            await _repositoryAsync.UpdateAsync(tarea);

            return new Response<int>(tarea.Id);
        }
    }
}
