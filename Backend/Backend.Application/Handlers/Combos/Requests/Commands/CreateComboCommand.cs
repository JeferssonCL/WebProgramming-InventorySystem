using Backend.Application.Dtos.Combo;
using Backend.Domain.Entities.Concretes;
using MediatR;

namespace Backend.Application.Handlers.Combos.Requests.Commands;

public class CreateComboCommand(CreateComboDto createComboDto) : IRequest<Combo>
{
    public CreateComboDto CreateComboDto { get; set; } = createComboDto;
}
