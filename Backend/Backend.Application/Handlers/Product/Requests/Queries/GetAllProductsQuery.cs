using Backend.Application.Dtos.Product;
using MediatR;
using MerchantService.Application.Dtos;

namespace Backend.Application.Handlers.Product.Requests.Queries
{
    public class GetAllProductsQuery : IRequest<PageDto<ProductDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public GetAllProductsQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
    }
}