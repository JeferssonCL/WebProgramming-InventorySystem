using Backend.Application.Dtos.Combo;
using MediatR;

namespace Backend.Application.Handlers.Combos.Requests.Queries;

public class GetComboByIdQuery(Guid id) : IRequest<ComboDto?>
{
    public Guid Id { get; set; } = id;
}
