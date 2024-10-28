using Backend.Application.Dtos;
using Backend.Application.Dtos.Combo;
using MediatR;

namespace Backend.Application.Handlers.Combos.Requests.Queries;

public class GetAllCombosQuery(int page, int pageSize) : IRequest<PaginatedResponseDto<ComboDto>>
{
    public int Page { get; set; } = page;
    public int PageSize { get; set; } = pageSize;
}
