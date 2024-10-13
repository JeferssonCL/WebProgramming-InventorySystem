using Backend.Application.Dtos.Product;
using MediatR;

namespace Backend.Application.Handlers.Product.Requests.Commands
{
    public class UpdateProductCommand(ProductDto product) : IRequest<ProductDto>
    {
        public ProductDto Product { get; set; } = product;
    }

}