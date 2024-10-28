using Backend.Domain.Entities.Concretes;

namespace Backend.Application.Services.Products.Interfaces
{
    public interface IInventoryService
    {
        Task ReduceInventory(List<OrderItem> orderItems);
    }
}
