using Backend.Application.Dtos.Order;
using Backend.Application.Handlers.Order.Request.Commands;
using MediatR;

namespace Backend.Application.Handlers.Order.RequestHandlers.Commands
{
    public class ProcessOrderCommandHandler : IRequestHandler<ProcessOrderCommand, ProcessOrderDto>
    {
        public Task<ProcessOrderDto> Handle(ProcessOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}