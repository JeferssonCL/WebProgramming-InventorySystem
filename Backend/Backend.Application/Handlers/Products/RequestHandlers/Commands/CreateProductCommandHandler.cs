using Backend.Application.Handlers.Products.Requests.Commands;
using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.Products.RequestHandlers.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IProductRepository _producRepository;
        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _producRepository = productRepository;
        }
        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.Product;
            product = await _producRepository.AddAsync(product);
            return product;
        }
    }
}