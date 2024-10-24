using Backend.Application.Dtos.checkoutSession;
using Backend.Application.Dtos.Order;
using Backend.Domain.Entities.Concretes;
using MediatR;

namespace Backend.Application.Handlers.OrderItems.Request.Commands;

public class CreateOrderItemCommand (OrderItem orderItem) : IRequest<OrderItem>
{
    public OrderItem Item { get; set; } = orderItem;
}
