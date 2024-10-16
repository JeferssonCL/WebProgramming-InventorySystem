using MediatR;
using Microsoft.AspNetCore.Mvc;
using Backend.Application.Dtos;
using Backend.Application.Handlers.Orders.Request.Commands;


namespace Backend.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;
    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public ActionResult<Dictionary<string, bool>> ProcessShoppingCart(ProcessCartDto processCartDto)
    {
        var result = _mediator.Send(new ProcessCartCommand(processCartDto));

        return Ok(new Dictionary<string, bool>
            {
                { "result", result.Result }
            });
    }

}
