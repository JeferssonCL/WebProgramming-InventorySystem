using Backend.Application.Dtos;
using Backend.Application.Dtos.Combo;
using Backend.Application.Handlers.Combos.Requests.Queries;
using Backend.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.Combos.RequestHandlers.Queries;

public class GetAllCombosQueryHandler(IComboRepository comboRepository)
    : IRequestHandler<GetAllCombosQuery, PaginatedResponseDto<ComboDto>>
{
    public async Task<PaginatedResponseDto<ComboDto>> Handle(GetAllCombosQuery request, CancellationToken cancellationToken)
    {
        var totalCombos = await comboRepository.GetAllAsync(request.Page, request.PageSize);
        var count = await comboRepository.GetCountAsync();
        var totalCombosDto = totalCombos.Select(combo => new ComboDto
        {
            Id = combo.Id,
            Name = combo.Name,
            Description = combo.Description,
            Price = combo.Price,
            DiscountPercent = combo.DiscountPercent,
            Products = combo.Products.Select(p => new ProductComboDto
            {
                Name = p.Name,
                Price = p.BasePrice,
                Brand = p.Brand,
                Description = p.Description
            }).ToList(),
            IsActive = combo.IsActive,
        }).ToList();

        return new PaginatedResponseDto<ComboDto>
        {
            Items = totalCombosDto,
            TotalCount = count,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}
