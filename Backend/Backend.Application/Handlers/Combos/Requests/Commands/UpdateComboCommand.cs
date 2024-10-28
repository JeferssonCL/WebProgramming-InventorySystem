using Backend.Application.Dtos.Combo;
using MediatR;

namespace Backend.Application.Handlers.Combos.Requests.Commands;

public class UpdateComboCommand(UpdateComboDto comboDto) : IRequest<ComboDto>
{
    public UpdateComboDto ComboDto { get; set; } = comboDto;
}
