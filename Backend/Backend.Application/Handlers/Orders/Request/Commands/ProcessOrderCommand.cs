using Backend.Application.Dtos;
using MediatR;

namespace Backend.Application.Handlers.Orders.Request.Commands
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