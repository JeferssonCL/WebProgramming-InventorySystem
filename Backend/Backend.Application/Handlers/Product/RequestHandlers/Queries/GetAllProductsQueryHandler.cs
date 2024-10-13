using Backend.Application.Dtos.Product;
using Backend.Application.Handlers.Product.Requests.Queries;
using MediatR;
using MerchantService.Application.Dtos;

namespace Backend.Application.Handlers.Product.RequestHandlers.Queries{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, PageDto<ProductDto>>
    {
        public Task<PageDto<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}