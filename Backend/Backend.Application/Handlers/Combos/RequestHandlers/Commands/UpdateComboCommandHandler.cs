using Backend.Application.Dtos.Combo;
using Backend.Application.Handlers.Combos.Requests.Commands;
using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.Combos.RequestHandlers.Commands;

public class UpdateComboCommandHandler(IComboRepository comboRepository, IProductRepository productRepository)
    : IRequestHandler<UpdateComboCommand, ComboDto>
{
    public async Task<ComboDto> Handle(UpdateComboCommand request, CancellationToken cancellationToken)
    {
        var comboToUpdate = await comboRepository.GetByIdAsync(request.ComboDto.Id);
        if (comboToUpdate == null) throw new ArgumentException("The requested combo was not found.");

        comboToUpdate.Name = request.ComboDto.Name ?? comboToUpdate.Name;
        comboToUpdate.Description = request.ComboDto.Description ?? comboToUpdate.Description;
        comboToUpdate.DiscountPercent = request.ComboDto.DiscountPercent ?? comboToUpdate.DiscountPercent;
        comboToUpdate.IsActive = request.ComboDto.IsActive ?? comboToUpdate.IsActive;
        comboToUpdate.ImageId = request.ComboDto.ImageId ?? comboToUpdate.ImageId;
        double totalPrice = 0;
        if (request.ComboDto.ProductsIds != null && request.ComboDto.ProductsIds.Count != 0)
        {
            comboToUpdate.Products = new List<Product>();
            foreach (var id in request.ComboDto.ProductsIds)
            {
                var product = await productRepository.GetByIdAsync(id);
                if (product == null) throw new Exception("We could not find this product in our database to add to the combo.");
                totalPrice += product.Price;
                comboToUpdate.Products.Add(product);
            }
            comboToUpdate.Price = totalPrice;
        } else {
            comboToUpdate.Products = comboToUpdate.Products;
            comboToUpdate.Price = comboToUpdate.Price;
        }

        comboToUpdate.UpdatedAt = DateTime.UtcNow;
        await comboRepository.UpdateAsync(comboToUpdate);
        return new ComboDto
        {
            Id = comboToUpdate.Id,
            Name = comboToUpdate.Name,
            Description = comboToUpdate.Description,
            Price = comboToUpdate.Price,
            DiscountPercent = comboToUpdate.DiscountPercent,
            Products = comboToUpdate.Products.Select(p => new ProductComboDto
            {
                Name = p.Name,
                Description = p.Description,
                Brand = p.Brand,
                Price = p.Price
            }).ToList(),
            IsActive = comboToUpdate.IsActive
        };
    }
}
