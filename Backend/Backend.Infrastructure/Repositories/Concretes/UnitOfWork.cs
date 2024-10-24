using Backend.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories.Concretes;

public class UnitOfWork(DbContext context, IOrderRepository ordersRepository,
    IPaymentTransactionRepository paymentTransactionRepository, IUserAddressRepository userAddressRepository,
    IOrderItemRepository orderItemRepository) : IUnitOfWork
{
    public IOrderRepository OrdersRepository { get; } = ordersRepository;
    public IPaymentTransactionRepository PaymentTransactionRepository { get; } = paymentTransactionRepository;
    public IUserAddressRepository UserAddressRepository { get; } = userAddressRepository;
    public IOrderItemRepository OrderItemRepository { get; } = orderItemRepository;

    private readonly DbContext _context = context;

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
