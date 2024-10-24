using Backend.Application.Handlers.Orders.Request.Commands;
using Backend.Domain.Entities.Concretes;
using Backend.Domain.Entities.Enums;
using Backend.Infrastructure.Repositories.Interfaces;
using DotNetEnv;
using MediatR;
using Stripe;
using Stripe.Checkout;
using PaymentMethod = Backend.Domain.Entities.Enums.PaymentMethod;

namespace Backend.Application.Handlers.Orders.RequestHandlers.Commands;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, string>
{
    private IUnitOfWork _unitOfWork;

    public CreateOrderCommandHandler(IUnitOfWork unitOfWork)
    {
        StripeConfiguration.ApiKey = Env.GetString("STRIPE_SECRET_KEY");
        _unitOfWork = unitOfWork;
    }

    public async Task<string> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var service = new SessionService();
            var sessionWithLineItems = await service.GetAsync(request.OrderToBeCreated.StripeSessionId, new SessionGetOptions
            {
                Expand = ["line_items", "line_items.data.price.product", "payment_intent"]
            }, cancellationToken: cancellationToken);

            if (sessionWithLineItems == null) throw new InvalidOperationException("Failed to retrieve session from Stripe.");

            var paymentMethod = sessionWithLineItems.PaymentMethodTypes.FirstOrDefault() ?? "Unknown";
            var transactionStatus = sessionWithLineItems.PaymentStatus ?? "Unknown";
            var orderStatus = MapStripeStatusToOrderStatus(transactionStatus);

            var order = new Order
            {
                UserId = request.OrderToBeCreated.Customer.Id,
                OrderDate = DateTime.UtcNow,
                OrderStatus = orderStatus,
                TotalPrice = sessionWithLineItems.AmountTotal ?? 0,
            };
            await _unitOfWork.OrdersRepository.AddAsync(order);

            var userAddress = new UserAddress
            {
                UserId = request.OrderToBeCreated.Customer.Id,
                Address = request.OrderToBeCreated.Customer.Address,
                City = request.OrderToBeCreated.Customer.City,
                Country = request.OrderToBeCreated.Customer.Country,
            };
            await _unitOfWork.UserAddressRepository.AddAsync(userAddress);

            var orderItems = sessionWithLineItems.LineItems.Data.Select(item => new OrderItem
            {
                OrderId = order.Id,
                ProductId = Guid.Parse(item.Price.Product.Metadata["ProductId"]),
                Quantity = (int)item.Quantity!,
                UnitPrice = (double)(item.Price.UnitAmount ?? 0) / 100,
                DiscountPercent = 0,
                TotalPrice = (double)(item.Price.UnitAmount ?? 0) * (item.Quantity ?? 0) / 100
            }).ToList();
            foreach (var orderItem in orderItems) await _unitOfWork.OrderItemRepository.AddAsync(orderItem);

            var paymentTransaction = new PaymentTransaction
            {
                OrderId = order.Id,
                PaymentMethod = MapPaymentMethodStringToEnum(paymentMethod),
                TransactionOrderStatus = MapPaymentStatusStringToEnum(transactionStatus),
                Amount = order.TotalPrice,
            };
            await _unitOfWork.PaymentTransactionRepository.AddAsync(paymentTransaction);

            return order.Id.ToString();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    private OrderStatus MapStripeStatusToOrderStatus(string stripeStatus)
    {
        return stripeStatus.ToLower() switch
        {
            "paid" => OrderStatus.Confirmed,
            "unpaid" => OrderStatus.Cancelled,
            _ => OrderStatus.Pending
        };
    }

    private PaymentStatus MapPaymentStatusStringToEnum(string paymentStatus)
    {
        return paymentStatus.ToLower() switch
        {
            "paid" => PaymentStatus.Paid,
            _ => PaymentStatus.Unpaid
        };
    }

    private PaymentMethod MapPaymentMethodStringToEnum(string paymentMethod)
    {
        return paymentMethod.ToLower() switch
        {
            "card" => PaymentMethod.CreditCard,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
