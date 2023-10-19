using Application.Features.Categorias.Commands.CreateCategoriaCommand;
using Application.Features.Categorias.Commands.DeleteCategoriaCommand;
using Application.Features.Categorias.Commands.UpdateCategoriaCommand;
using Application.Features.Categorias.Queries.GetAllCategorias;
using Application.Features.Categorias.Queries.GetAllCategoriasById;
using Microsoft.AspNetCore.Mvc;

namespace WebApiToDo.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CategoriaController : BaseApiController
    {
        [HttpGet()]
        public async Task<IActionResult> Get() =>
            Ok(await Mediator.Send(new GetAllCategoriasQuery() { }));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) =>
            Ok(await Mediator.Send(new GetCategoriaByIdQuery() { Id = id }));

        [HttpPost]
        public async Task<IActionResult> Post(CreateCategoriaCommand command) =>
            Ok(await Mediator.Send(command));

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateCategoriaCommand command)
        {
            if (id != command.Id)
                return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => 
            Ok(await Mediator.Send(new DeleteCategoriaCommand() { Id = id }));
    }
}
