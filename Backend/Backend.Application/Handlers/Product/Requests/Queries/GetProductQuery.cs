using Backend.Application.Dtos.Product;
using MediatR;

namespace Backend.Application.Handlers.Product.Requests.Queries
{
    public class GetProductQuery(Guid id) : IRequest<ProductDto>
    {
        public Guid Id { get; set; } = id;
    }
}