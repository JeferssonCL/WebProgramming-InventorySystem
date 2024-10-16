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
    private readonly IMapper _mapper;

    public ShoppingCartController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public ActionResult<Dictionary<string, string>> InitCheckoutSession(List<ShoppingCartItemDto> shoppingCartItemDtos)
    {
        foreach (var shoppingCartItemDto in shoppingCartItemDtos)
            Console.WriteLine(shoppingCartItemDto);

        var result = _mediator.Send(new CreateCheckoutSessionCommand(shoppingCartItemDtos));

        return Ok(new Dictionary<string, string>
        {
            { "id", result.Result }
        });
    }

}
