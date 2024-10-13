using Backend.Domain.Entities.Concretes;
using MediatR;

namespace Backend.Application.Handlers.Products.Requests.Queries
{
    public class GetAllProductsQuery : IRequest<(List<Product>, int)>
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