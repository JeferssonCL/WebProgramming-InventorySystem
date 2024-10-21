using Backend.Application.Handlers.Products.Requests.Commands;
using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.DAO.Interfaces;
using Backend.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.Products.RequestHandlers.Commands
{
    public class UpdateProductCommandHandler(IProductRepository productRepository)
        : IRequestHandler<UpdateProductCommand, Product>
    {
        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.Product;
            product = await productRepository.UpdateAsync(product);
            return product;
        }
    }
}
