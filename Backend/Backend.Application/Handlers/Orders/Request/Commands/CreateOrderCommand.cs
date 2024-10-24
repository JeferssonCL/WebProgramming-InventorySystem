using Backend.Application.Dtos.checkoutSession;
using Backend.Application.Dtos.Order;
using MediatR;

namespace Backend.Application.Handlers.Orders.Request.Commands;

public class CreateOrderCommand (OrderDTO order) : IRequest<string>
{
public OrderDTO OrderToBeCreated { get; set; } = order;
}
