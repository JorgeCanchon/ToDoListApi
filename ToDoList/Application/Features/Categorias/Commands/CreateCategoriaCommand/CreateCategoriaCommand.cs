using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categorias.Commands.CreateCategoriaCommand
{
    public  class CreateCategoriaCommand : IRequest<Response<int>> 
    {
        public string Nombre { get; set; }
    }

    public class CreateCategoriaCommandHandler : IRequestHandler<CreateCategoriaCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Categoria> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateCategoriaCommandHandler(IRepositoryAsync<Categoria> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Response<int>> Handle(CreateCategoriaCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<Categoria>(request);
            nuevoRegistro.Estado = true;
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);
            return new Response<int>(data.Id);
        }
    }
}
