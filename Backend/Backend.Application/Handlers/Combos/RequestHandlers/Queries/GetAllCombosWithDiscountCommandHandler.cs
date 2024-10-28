using Backend.Application.Dtos;
using Backend.Application.Dtos.Combo;
using Backend.Application.Handlers.Combos.Requests.Queries;
using Backend.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.Combos.RequestHandlers.Queries;

public class GetAllCombosWithDiscountCommandHandler(IComboRepository comboRepository)
    : IRequestHandler<GetAllCombosWithDiscountCommand, PaginatedResponseDto<ComboWithDiscountDto>>
{
    public async Task<PaginatedResponseDto<ComboWithDiscountDto>> Handle(GetAllCombosWithDiscountCommand request, CancellationToken cancellationToken)
    {
        var totalCombos = await comboRepository.GetAllAsync(request.Page, request.PageSize);
        var count = await comboRepository.GetCountAsync();
        var totalCombosDto = totalCombos
            .Where(combo => combo.DiscountPercent > 0)
            .Select(combo => new ComboWithDiscountDto
                {
                    Id = combo.Id,
                    Name = combo.Name,
                    Description = combo.Description,
                    Price = combo.Price,
                    DiscountPercent = combo.DiscountPercent,
                    PriceWithDiscount = combo.Price * (double)(1 - combo.DiscountPercent / 100m),
                    Products = combo.Products.Select(p => new ProductComboDto
                    {
                        Name = p.Name,
                        Price = p.BasePrice,
                        Brand = p.Brand,
                        Description = p.Description
                    }).ToList(),
                    IsActive = combo.IsActive,
                }).ToList();

        return new PaginatedResponseDto<ComboWithDiscountDto>
        {
            Items = totalCombosDto,
            TotalCount = count,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}
