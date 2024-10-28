using Backend.Application.Dtos;
using Backend.Application.Dtos.Combo;
using Backend.Application.Handlers.Combos.Requests.Queries;
using Backend.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.Combos.RequestHandlers.Queries;

public class GetAllCombosWithDiscountCommandHandler(IComboRepository comboRepository, IImageRepository imageRepository)
    : IRequestHandler<GetAllCombosWithDiscountCommand, PaginatedResponseDto<ComboWithDiscountDto>>
{
    public async Task<PaginatedResponseDto<ComboWithDiscountDto>> Handle(GetAllCombosWithDiscountCommand request, CancellationToken cancellationToken)
    {
        var totalCombos = await comboRepository.GetAllAsync(request.Page, request.PageSize);
        var count = await comboRepository.GetCountAsync();

        var totalCombosDto = new List<ComboWithDiscountDto>();

        foreach (var combo in totalCombos.Where(c => c.DiscountPercent > 0))
        {
            var comboImage = (await imageRepository.GetByIdAsync(combo.ImageId))!;

            var comboDto = new ComboWithDiscountDto
            {
                Id = combo.Id,
                Name = combo.Name,
                Description = combo.Description,
                Price = combo.Price,
                DiscountPercent = combo.DiscountPercent,
                ComboImageDto = new ComboImageDto
                {
                    AltText = comboImage.AltText,
                    Url = comboImage.Url
                },
                PriceWithDiscount = combo.Price * (double)(1 - combo.DiscountPercent / 100m),
                Products = combo.Products.Select(p => new ProductComboDto
                {
                    Name = p.Name,
                    Price = p.BasePrice,
                    Brand = p.Brand,
                    Description = p.Description
                }).ToList(),
                IsActive = combo.IsActive,
            };

            totalCombosDto.Add(comboDto);
        }

        return new PaginatedResponseDto<ComboWithDiscountDto>
        {
            Items = totalCombosDto,
            TotalCount = count,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}
