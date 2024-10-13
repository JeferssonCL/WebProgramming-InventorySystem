using Backend.Application.Dtos.Product;
using Backend.Application.Handlers.Product.Requests.Queries;
using MediatR;

namespace Backend.Application.Handlers.Product.RequestHandlers.Queries
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
    {
        public Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}