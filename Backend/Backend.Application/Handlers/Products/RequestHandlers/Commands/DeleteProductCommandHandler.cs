using Backend.Application.Handlers.Products.Requests.Commands;
using Backend.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.Products.RequestHandlers.Commands
{
    public class DeleteProductCommandHandler(IProductRepository productRepository)
        : IRequestHandler<DeleteProductCommand, bool>
    {
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await productRepository.DeleteAsync(
                request.Id
            );
        }
    }
}
