using Backend.Application.Services.Products.Interfaces;
using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.Repositories.Interfaces;

namespace Backend.Application.Services.Products.Concretes
{
    public class InventoryService : IInventoryService
    {

        private readonly IUnitOfWork _unitOfWork;

        public InventoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task ReduceInventory(List<OrderItem> orderItems)
        {
            foreach (var item in orderItems)
            {
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(item.ProductId);

                if (product is null) throw new InvalidOperationException("Product not found.");

                product.Stock -= item.Quantity;
                await _unitOfWork.ProductRepository.UpdateAsync(product);
            }
        }
    }
}
