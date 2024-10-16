using Backend.Application.Handlers.Orders.Request.Commands;
using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.DAO.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.Orders.RequestHandlers.Commands
{
    public class ProcessOrderCommandHandler : IRequestHandler<ProcessOrderCommand, bool>
    {
        public Task<bool> Handle(ProcessOrderCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }
    }
}