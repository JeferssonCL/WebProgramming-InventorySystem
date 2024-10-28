using Backend.Application.Dtos;
using Backend.Application.Dtos.Combo;
using Backend.Application.Handlers.Combos.Requests.Queries;
using Backend.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.Combos.RequestHandlers.Queries;

public class GetAllCombosQueryHandler(IComboRepository comboRepository, IImageRepository imageRepository)
    : IRequestHandler<GetAllCombosQuery, PaginatedResponseDto<ComboDto>>
{
    public async Task<PaginatedResponseDto<ComboDto>> Handle(GetAllCombosQuery request, CancellationToken cancellationToken)
    {
        var totalCombos = await comboRepository.GetAllAsync(request.Page, request.PageSize);
        var count = await comboRepository.GetCountAsync();

        var totalCombosDto = new List<ComboDto>();

        foreach (var combo in totalCombos)
        {
            var comboImage = await imageRepository.GetByIdAsync(combo.ImageId);

            var comboDto = new ComboDto
            {
                Id = combo.Id,
                Name = combo.Name,
                Description = combo.Description,
                Price = combo.Price,
                DiscountPercent = combo.DiscountPercent,
                ComboImageDto = (comboImage != null ? new ComboImageDto
                {
                    AltText = comboImage.AltText,
                    Url = comboImage.Url
                } : null)!,
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

        return new PaginatedResponseDto<ComboDto>
        {
            Items = totalCombosDto,
            TotalCount = count,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}
