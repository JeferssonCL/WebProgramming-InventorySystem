using Backend.Application.Handlers.OrderItems.Request.Commands;
using Backend.Application.Handlers.Orders.Request.Commands;
using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.OrderItems.RequestHandlers.Commands;

public class CreateOrderItemCommandHandler(IOrderItemRepository orderItemRepository) : IRequestHandler<CreateOrderItemCommand, OrderItem>
{
    public async Task<OrderItem> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
    {
        OrderItem orderItem = request.Item;
        orderItem = await orderItemRepository.AddAsync(orderItem);
        return orderItem;
    }
}
