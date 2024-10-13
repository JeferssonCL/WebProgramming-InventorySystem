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
        public ActionResult<ProcessOrderDto> ProcessOrder(ProcessOrderDto processOrderDto)
        {
            var product = _mediator.Send(new ProcessOrderCommand(processOrderDto));

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

    }
}