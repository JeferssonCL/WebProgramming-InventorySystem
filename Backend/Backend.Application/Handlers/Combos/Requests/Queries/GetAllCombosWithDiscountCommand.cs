using Backend.Application.Dtos;
using Backend.Application.Dtos.Combo;
using MediatR;

namespace Backend.Application.Handlers.Combos.Requests.Queries;

public class GetAllCombosWithDiscountCommand(int page, int pageSize) : IRequest<PaginatedResponseDto<ComboWithDiscountDto>>
{
    public int Page { get; set; } = page;
    public int PageSize { get; set; } = pageSize;
}
