using System.Drawing;
using Backend.Application.Handlers.Products.Requests.Queries;
using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.DAO.Interfaces;
using Backend.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.Products.RequestHandlers.Queries
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product?>
    {
        private readonly IProductRepository _productRepository;

        public GetProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product?> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            System.Console.WriteLine("+=========================================================");
            System.Console.WriteLine(product.Categories);


            foreach (ProductAttribute productAttribute in product.ProductAttributes)
            {
                System.Console.WriteLine("type Id "+productAttribute.Id);
                System.Console.WriteLine("type Image "+productAttribute.Image);
                System.Console.WriteLine("type ProductId "+productAttribute.ProductId);
                System.Console.WriteLine("type Value "+productAttribute.Value);
                System.Console.WriteLine("type Variant "+productAttribute?.Variant?.Id);
            }

            System.Console.WriteLine("+=========================================================");
            return product;
        }
    }
}