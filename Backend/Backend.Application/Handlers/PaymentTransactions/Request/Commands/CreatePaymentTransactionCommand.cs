using Backend.Domain.Entities.Concretes;
using MediatR;

namespace Backend.Application.Handlers.PaymentTransactions.Request.Commands;

public class CreatePaymentTransactionCommand(PaymentTransaction paymentTransaction) : IRequest<PaymentTransaction>
{
    public PaymentTransaction Payment { get; set; } = paymentTransaction;
}
