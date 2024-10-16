using Backend.Application.Dtos;
using MediatR;

namespace Backend.Application.Handlers.Orders.Request.Commands;

public class ProcessCartCommand : IRequest<bool>
{
    public ProcessCartDto ProcessCartDto { get; set; }

    public ProcessCartCommand(ProcessCartDto processOrderDto)
    {
        ProcessCartDto = processOrderDto;
    }
}