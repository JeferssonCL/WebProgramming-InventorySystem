using Backend.Application.Dtos.checkoutSession;
using Backend.Domain.Entities.Concretes;
using MediatR;

namespace Backend.Application.Handlers.Checkout_Session.Request.Commands;

public class CreateCheckoutSessionCommand(List<ShoppingCartItemDto> shoppingCartList) : IRequest<bool>
{
    public List<ShoppingCartItemDto> ShoppingCartList { get; set; } = shoppingCartList;
}
