using MediatR;
using Microsoft.AspNetCore.Mvc;
using Backend.Application.Handlers.Orders.Request.Commands;
using Backend.Application.Dtos;

namespace Backend.Application.Api.Controllers
{
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
        public ActionResult<Dictionary<string, bool>> ProcessOrder(ProcessOrderDto processOrderDto)
        {
            var result = _mediator.Send(new ProcessOrderCommand(processOrderDto));

            return Ok(new Dictionary<string, bool>
            {
                { "result", result.Result }
            });
        }

    }
}