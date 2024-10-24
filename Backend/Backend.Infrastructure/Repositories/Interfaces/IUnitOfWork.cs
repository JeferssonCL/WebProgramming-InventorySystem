namespace Backend.Infrastructure.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IOrderRepository OrdersRepository { get; }
    public IPaymentTransactionRepository PaymentTransactionRepository { get; }
    public IUserAddressRepository UserAddressRepository { get; }
    public IOrderItemRepository OrderItemRepository { get; }
    public Task<int> CommitAsync();
}

