using Backend.Application.Dtos.Combo;
using Backend.Application.Handlers.Combos.Requests.Commands;
using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.Combos.RequestHandlers.Commands;

public class CreateComboCommandHandler(IComboRepository comboRepository,  IProductRepository productRepository)
    : IRequestHandler<CreateComboCommand, Combo>
{
    public async Task<Combo> Handle(CreateComboCommand request, CancellationToken cancellationToken)
    {
        var comboDto = request.CreateComboDto;

        var combo = new Combo
        {
            Name = comboDto.Name,
            Description = comboDto.Description,
            Price = 0,
            DiscountPercent = comboDto.DiscountPercent,
            Products = new List<Product>(),
            ImageId = comboDto.ComboImageId
        };

        double totalPrice = 0;
        if (comboDto.ProductIds.Count > 0)
        {
            foreach (var id in comboDto.ProductIds)
            {
                var product = await productRepository.GetByIdAsync(id);
                if (product == null) throw new Exception("We not found this product in our db to add into combo.");
                totalPrice += product.BasePrice;
                combo.Products.Add(product);
            }

            combo.Price = totalPrice;
        } else throw new ArgumentException("There must be at least one product in the combo.");

        combo = await comboRepository.AddAsync(combo);
        return combo;
    }
}
