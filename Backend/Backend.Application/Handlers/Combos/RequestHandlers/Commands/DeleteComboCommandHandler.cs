using Backend.Application.Handlers.Combos.Requests.Commands;
using Backend.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.Combos.RequestHandlers.Commands;

public class DeleteComboCommandHandler(IComboRepository comboRepository)
: IRequestHandler<DeleteComboCommand, bool>
{
    public async Task<bool> Handle(DeleteComboCommand request, CancellationToken cancellationToken)
    {
        return await comboRepository.DeleteAsync(request.Id);
    }
}
