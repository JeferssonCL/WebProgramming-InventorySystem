using Backend.Application.Dtos.Combo;
using Backend.Application.Handlers.Combos.RequestHandlers.Queries;
using Backend.Application.Handlers.Combos.Requests.Commands;
using Backend.Application.Handlers.Combos.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ComboController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Dictionary<string, bool>>> Create([FromBody] CreateComboDto request)
    {
        var result = await mediator.Send(new CreateComboCommand(request));

        return Ok(new Dictionary<string, string>
        {
            { "result", result.Id.ToString() }
        });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ComboDto>> GetById(Guid id)
    {
        var image = await mediator.Send(new GetComboByIdQuery(id));
        if (image == null) return NotFound();
        return Ok(image);
    }

    [HttpGet]
    public async Task<ActionResult<List<ComboDto>>> GetAll(int page = 1, int pageSize = 10)
    {
        var result = await mediator.Send(new GetAllCombosQuery(page, pageSize));
        return Ok(result);
    }

    [HttpGet("discount")]
    public async Task<ActionResult<List<ComboWithDiscountDto>>> GetAllProductWithDiscount(int page = 1, int pageSize = 10)
    {
        var result = await mediator.Send(new GetAllCombosWithDiscountCommand(page, pageSize));
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateComboDto request)
    {
        if (id != request.Id) return BadRequest();
        var result = await mediator.Send(new UpdateComboCommand(request));

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await mediator.Send(new DeleteComboCommand(id));

        return Ok(result);
    }
}
