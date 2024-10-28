using Backend.Domain.Entities.Concretes;
using MediatR;

namespace Backend.Application.Handlers.Combos.Requests.Queries;

public class GetAllDiscountProductsQuery(int page, int pageSize) : IRequest<(List<Product>, int)>
{
    public int Page { get; set; } = page;
    public int PageSize { get; set; } = pageSize;
}
