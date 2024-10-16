using Backend.Application.Handlers.Orders.Request.Commands;
using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.DAO.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.Orders.RequestHandlers;

public class ProcessOrderCommandHandler : IRequestHandler<ProcessOrderCommand, bool>
{
    private readonly IGenericDAO<Order> _orderDao;
    public ProcessOrderCommandHandler(IGenericDAO<Order> orderDao)
    {
        _orderDao = orderDao;
    }
    public Task<bool> Handle(ProcessOrderCommand request, CancellationToken cancellationToken)
    {
        var order = request.ProcessOrderDto;
        return Task.FromResult(true);
    }
}