using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Tareas.Commands.CreateTareaCommand
{
    public class CreateTareaCommand : IRequest<Response<int>>
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int CategoriaId { get; set; }
        public DateTime FechaLimite { get; set; }
    }

    public class CreateTareaCommandHandler : IRequestHandler<CreateTareaCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Tarea> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateTareaCommandHandler(IRepositoryAsync<Tarea> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Response<int>> Handle(CreateTareaCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<Tarea>(request);
            nuevoRegistro.Estado = true;
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);
            return new Response<int>(data.Id);
        }
    }
}
