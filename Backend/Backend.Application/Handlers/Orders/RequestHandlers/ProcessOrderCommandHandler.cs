using Backend.Application.Dtos;
using Backend.Application.Handlers.Orders.Request.Commands;
using MediatR;

namespace Backend.Application.Handlers.Orders.RequestHandlers.Commands
{
    public class ProcessOrderCommandHandler : IRequestHandler<ProcessOrderCommand, ProcessOrderDto>
    {
        public Task<ProcessOrderDto> Handle(ProcessOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}