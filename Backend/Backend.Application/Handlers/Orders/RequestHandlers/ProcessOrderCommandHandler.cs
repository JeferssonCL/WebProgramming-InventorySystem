using Backend.Application.Handlers.Orders.Request.Commands;
using Backend.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.Orders.RequestHandlers;

public class ProcessOrderCommandHandler : IRequestHandler<ProcessOrderCommand, bool>
{
    private readonly IOrderRepository _orderRepository;
    public ProcessOrderCommandHandler(IOrderRepository orderRepository)
    { 
        _orderRepository = orderRepository;
    }
    public Task<bool> Handle(ProcessOrderCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(true);
    }

}