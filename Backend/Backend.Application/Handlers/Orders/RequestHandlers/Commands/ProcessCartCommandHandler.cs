using Backend.Application.Handlers.Orders.Request.Commands;
using Backend.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.Orders.RequestHandlers.Commands;

public class ProcessCartCommandHandler : IRequestHandler<ProcessCartCommand, bool>
{
    private readonly IOrderRepository _orderRepository;
    public ProcessCartCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public Task<bool> Handle(ProcessCartCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(true);
    }
}