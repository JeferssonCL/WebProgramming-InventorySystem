using Backend.Application.Handlers.CheckoutSession.Request.Commands;
using DotNetEnv;
using MediatR;
using Stripe;
using Stripe.Checkout;

namespace Backend.Application.Handlers.CheckoutSession.RequestHandlers;

public class CreateCheckoutSessionCommandHandler : IRequestHandler<CreateCheckoutSessionCommand, string>
{
    public CreateCheckoutSessionCommandHandler()
    {
        StripeConfiguration.ApiKey = Env.GetString("STRIPE_SECRET_KEY");
    }

    public async Task<string> Handle(CreateCheckoutSessionCommand request, CancellationToken cancellationToken)
    {
        var lineItems = request.ShoppingCartList.Select(product =>
            new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    Currency = "usd",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = product.Name,
                        Images = [product.ImageUrl],
                        Metadata = new Dictionary<string, string>
                    {
                        { "ProductId", product.Id.ToString() }
                    }
                    },
                    UnitAmount = (long)(product.Price * 100),
                },
                Quantity = product.Quantity,
            }).ToList();

        var options = new SessionCreateOptions
        {
            PaymentMethodTypes = ["card"],
            LineItems = lineItems,
            Mode = "payment",
            SuccessUrl = "http://localhost:5173/payment_transaction/success?session_id={CHECKOUT_SESSION_ID}",
            CancelUrl = "http://localhost:5173/payment_transaction/failed?session_id={CHECKOUT_SESSION_ID}",
            Discounts = new List<SessionDiscountOptions>
            {
                new SessionDiscountOptions
                {
                    PromotionCode = "promo_1QDWamP3WBhplXYwJGtEWiV7"
                }
            }
        };

        var service = new SessionService();
        var session = await service.CreateAsync(options, cancellationToken: cancellationToken);
        return await Task.FromResult(session.Id);
    }
}
