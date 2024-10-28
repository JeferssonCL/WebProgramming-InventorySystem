using MediatR;

namespace Backend.Application.Handlers.Combos.Requests.Commands;

public class DeleteComboCommand(Guid id) : IRequest<bool>
{
public Guid Id { get; set; } = id;
}
