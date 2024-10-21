using Backend.Application.Dtos.checkoutSession;
using Backend.Application.Handlers.CheckoutSession.Request.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Backend.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CheckoutController(IMediator mediator) : ControllerBase
{
    [HttpPost("submit-cart")]
    public ActionResult<Dictionary<string, string>> InitCheckoutSession(List<ShoppingCartItemDto> itemsToBuy)
    {
        var result = mediator.Send(new CreateCheckoutSessionCommand(itemsToBuy));
        return Ok(new Dictionary<string, string>
        {
            { "id", result.Result }
        });
    }
}
