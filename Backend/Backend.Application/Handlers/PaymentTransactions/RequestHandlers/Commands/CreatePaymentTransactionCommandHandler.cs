using Backend.Application.Handlers.PaymentTransactions.Request.Commands;
using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.PaymentTransactions.RequestHandlers.Commands;

public class CreatePaymentTransactionCommandHandler(IPaymentTransactionRepository paymentTransactionRepository) : IRequestHandler<CreatePaymentTransactionCommand, PaymentTransaction>
{
    public async Task<PaymentTransaction> Handle(CreatePaymentTransactionCommand request, CancellationToken cancellationToken)
    {
        PaymentTransaction orderItem = request.Payment;
        orderItem = await paymentTransactionRepository.AddAsync(orderItem);
        return orderItem;
    }
}
