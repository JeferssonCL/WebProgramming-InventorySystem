using MediatR;
using Microsoft.AspNetCore.Mvc;
using Backend.Application.Dtos.Order;
using Backend.Application.Handlers.Orders.Request.Commands;

namespace Backend.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public ActionResult<Dictionary<string, bool>> CreateOrder([FromBody] OrderDTO request)
    {
        var result = mediator.Send(new CreateOrderCommand(request));

        return Ok(new Dictionary<string, bool>
        {
            { "result", result != null }
        });
    }
}
