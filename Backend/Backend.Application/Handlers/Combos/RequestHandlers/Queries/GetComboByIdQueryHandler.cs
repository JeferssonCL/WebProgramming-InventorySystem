using Backend.Application.Dtos.Combo;
using Backend.Application.Handlers.Combos.Requests.Queries;
using Backend.Infrastructure.Repositories.Concretes;
using Backend.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.Combos.RequestHandlers.Queries;

public class GetComboByIdQueryHandler(IComboRepository comboRepository, IImageRepository imageRepository)
    : IRequestHandler<GetComboByIdQuery, ComboDto?>
{
    public async Task<ComboDto?> Handle(GetComboByIdQuery request, CancellationToken cancellationToken)
    {
        var combo = await comboRepository.GetByIdAsync(request.Id);
        var image = await imageRepository.GetByIdAsync(combo!.ImageId);
        return new ComboDto
        {
            Id = combo!.Id,
            Name = combo.Name,
            Description = combo.Description,
            Price = combo.Price,
            DiscountPercent = combo.DiscountPercent,
            ComboImageDto = new ComboImageDto { AltText = image!.AltText, Url = image.Url },
            Products = combo.Products.Select(p => new ProductComboDto
            {
                Name = p.Name,
                Price = p.BasePrice,
                Brand = p.Brand,
                Description = p.Description
            }).ToList(),
            IsActive = combo.IsActive,
        };
    }
}
