using Application.Exceptions;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categorias.Commands.UpdateCategoriaCommand
{
    public class UpdateCategoriaCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class UpdateCategoriaCommandHandler : IRequestHandler<UpdateCategoriaCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Categoria> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateCategoriaCommandHandler(IRepositoryAsync<Categoria> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Response<int>> Handle(UpdateCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = await _repositoryAsync.GetBySpecAsync(new ActivoCategoriaByIdSpecification(request.Id, true));
            if (categoria == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }

            categoria.Nombre = request.Nombre;

            await _repositoryAsync.UpdateAsync(categoria);

            return new Response<int>(categoria.Id);
        }
    }
}
