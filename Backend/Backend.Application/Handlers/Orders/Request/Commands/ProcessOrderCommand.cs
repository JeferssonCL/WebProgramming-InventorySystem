using Backend.Application.Dtos;
using MediatR;

namespace Backend.Application.Handlers.Orders.Request.Commands;

public class ProcessOrderCommand : IRequest<bool>
{
    public ProcessOrderDto ProcessOrderDto { get; set; }

    public ProcessOrderCommand(ProcessOrderDto processOrderDto)
    {
        ProcessOrderDto = processOrderDto;
    }
}