using Backend.Application.Handlers.Product.Requests.Commands;
using MediatR;

namespace Backend.Application.Handlers.Product.RequestHandlers.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        public Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}