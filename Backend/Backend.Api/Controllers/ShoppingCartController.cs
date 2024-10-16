using AutoMapper;
using Backend.Application.Dtos;
using Backend.Application.Dtos.checkoutSession;
using Backend.Application.Handlers.Checkout_Session.Request.Commands;
using Backend.Domain.Entities.Concretes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[ApiController]
[Route("api/[controller]/Submit-cart")]
public class ShoppingCartController : ControllerBase
{
    private readonly IMediator _mediator;

    public ShoppingCartController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public ActionResult<Dictionary<string, string>> InitCheckoutSession(List<ShoppingCartItemDto> shoppingCartItemDtos)
    {
        var result = _mediator.Send(new CreateCheckoutSessionCommand(shoppingCartItemDtos));

        return Ok(new Dictionary<string, string>
        {
            { "id", result.Result }
        });
    }

}
