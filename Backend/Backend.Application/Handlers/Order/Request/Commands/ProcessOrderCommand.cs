using Backend.Application.Dtos.Order;
using MediatR;

namespace Backend.Application.Handlers.Order.Request.Commands
{
    public class ProcessOrderCommand : IRequest<ProcessOrderDto>
    {
        public ProcessOrderDto ProcessOrderDto { get; set; }

        public ProcessOrderCommand(ProcessOrderDto processOrderDto)
        {
            ProcessOrderDto = processOrderDto;
        }
    }
}