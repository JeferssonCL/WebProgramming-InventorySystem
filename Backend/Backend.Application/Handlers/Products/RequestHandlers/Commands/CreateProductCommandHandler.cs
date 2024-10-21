using Backend.Application.Handlers.Products.Requests.Commands;
using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.Products.RequestHandlers.Commands;

public class CreateProductCommandHandler(IProductRepository productRepository)
    : IRequestHandler<CreateProductCommand, Product>
{
    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = request.Product;
        product = await productRepository.AddAsync(product);
        return product;
    }

}
