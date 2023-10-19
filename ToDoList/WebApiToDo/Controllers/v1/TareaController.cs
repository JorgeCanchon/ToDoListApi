using Application.Features.Tareas.Commands.CreateTareaCommand;
using Application.Features.Tareas.Commands.DeleteTareaCommand;
using Application.Features.Tareas.Commands.UpdateTareaCommand;
using Application.Features.Tareas.Queries.GetAllTareaById;
using Application.Features.Tareas.Queries.GetAllTareas;
using Microsoft.AspNetCore.Mvc;

namespace WebApiToDo.Controllers.v1
{
    [ApiVersion("1.0")]
    public class TareaController : BaseApiController
    {
        [HttpGet()]
        public async Task<IActionResult> Get() =>
           Ok(await Mediator.Send(new GetAllTareasQuery() { }));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) =>
           Ok(await Mediator.Send(new GetTareaByIdQuery() { Id = id }));

        [HttpPost]
        public async Task<IActionResult> Post(CreateTareaCommand command) =>
             Ok(await Mediator.Send(command));
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateTareaCommand command)
        {
            if (id != command.Id)
                return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) =>
            Ok(await Mediator.Send(new DeleteTareaCommand() { Id = id }));
    }
}
