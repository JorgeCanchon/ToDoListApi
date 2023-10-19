using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categorias.Commands.DeleteCategoriaCommand
{
    public class DeleteCategoriaCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteCategoriaCommandHandler : IRequestHandler<DeleteCategoriaCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Categoria> _repositoryAsync;

        public DeleteCategoriaCommandHandler(IRepositoryAsync<Categoria> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
        }

        public async Task<Response<int>> Handle(DeleteCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = await _repositoryAsync.GetBySpecAsync(new ActivoCategoriaByIdSpecification(request.Id, true));
            if (categoria == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }

            categoria.Activo = false;

            await _repositoryAsync.UpdateAsync(categoria);

            return new Response<int>(categoria.Id);
        }
    }
}
