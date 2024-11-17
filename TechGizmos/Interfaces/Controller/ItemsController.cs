using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechGizmos.TechGizmos.Application.Internal.Commands;
using TechGizmos.TechGizmos.Application.Internal.Queries;

namespace TechGizmos.TechGizmos.Interfaces.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Item>> Get()
        {
            return await _mediator.Send(new GetAllItemsQuery());
        }

        [HttpGet("{id}")]
        public async Task<Item> Get(string id)
        {
            return await _mediator.Send(new GetItemByIdQuery(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateItemCommand command)
        {
            try
            {
                var id = await _mediator.Send(command);
                return CreatedAtAction(nameof(Get), new { id }, command);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message }); // Devuelve el mensaje de error detallado
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, UpdateItemCommand command)
        {
            if (id != command.Id) return BadRequest();
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _mediator.Send(new DeleteItemCommand(id));
            return NoContent();
        }
    }
}
