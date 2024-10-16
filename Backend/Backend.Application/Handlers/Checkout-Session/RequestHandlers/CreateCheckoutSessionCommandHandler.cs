using Backend.Application.Handlers.Checkout_Session.Request.Commands;
using DotNetEnv;
using MediatR;
using Stripe;
using Stripe.Checkout;

namespace Backend.Application.Handlers.Checkout_Session.RequestHandlers;

public class CreateCheckoutSessionCommandHandler : IRequestHandler<CreateCheckoutSessionCommand, string>
{
    public CreateCheckoutSessionCommandHandler()
    {
        StripeConfiguration.ApiKey = Env.GetString("STRIPE_SECRET_KEY");
    }

    public async Task<string> Handle(CreateCheckoutSessionCommand request, CancellationToken cancellationToken)
    {
        var lineItems = request.ShoppingCartList.Select(product =>
            new SessionLineItemOptions {
            PriceData = new SessionLineItemPriceDataOptions
            {
                Currency = "usd",
                ProductData = new SessionLineItemPriceDataProductDataOptions
                {
                    Name = product.Name,
                    Images = [product.ImageUrl]
                }, UnitAmount = (long)(product.Price * 100),
            },
            Quantity = product.Quantity,
        }).ToList();

        var options = new SessionCreateOptions
        {
            PaymentMethodTypes = ["card"],
            LineItems = lineItems,
            Mode = "payment",
            SuccessUrl = "http://localhost:5173/payment_transaction/success",
            CancelUrl = "http://localhost:5173/payment_transaction/failed",
        };

        var service = new SessionService();
        var session = await service.CreateAsync(options, cancellationToken: cancellationToken);
        return await Task.FromResult(session.Id);
    }
}
