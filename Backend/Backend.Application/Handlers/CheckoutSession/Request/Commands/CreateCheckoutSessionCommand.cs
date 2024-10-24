using Backend.Application.Dtos.checkoutSession;
using MediatR;

namespace Backend.Application.Handlers.CheckoutSession.Request.Commands;

public class CreateCheckoutSessionCommand(List<ShoppingCartItemDto> itemsToBuy) : IRequest<string>
{
    public List<ShoppingCartItemDto> ShoppingCartList { get; set; } = itemsToBuy;
}
