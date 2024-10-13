using Backend.Application.Dtos;
using Backend.Application.Handlers.Orders.Request.Commands;
using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.DAO.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.Orders.RequestHandlers.Commands
{
    public class ProcessOrderCommandHandler : IRequestHandler<ProcessOrderCommand, ProcessOrderDto>
    {
        private readonly IGenericDAO<Order> _orderDao;
        public Task<ProcessOrderDto> Handle(ProcessOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}