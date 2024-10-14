using Backend.Application.Dtos;
using Backend.Application.Handlers.Orders.Request.Commands;
using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.DAO.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.Orders.RequestHandlers.Commands
{
    public class ProcessOrderCommandHandler : IRequestHandler<ProcessOrderCommand, bool>
    {
        private readonly IGenericDAO<Order> _orderDao;
        public Task<bool> Handle(ProcessOrderCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(true );
        }
    }
}