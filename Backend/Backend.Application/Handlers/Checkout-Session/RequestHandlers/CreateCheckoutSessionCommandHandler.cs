using Backend.Application.Handlers.Checkout_Session.Request.Commands;
using MediatR;
using Stripe.Checkout;

namespace Backend.Application.Handlers.Checkout_Session.RequestHandlers;

public class CreateCheckoutSessionCommandHandler : IRequestHandler<CreateCheckoutSessionCommand, bool>
{
    public async Task<bool> Handle(CreateCheckoutSessionCommand request, CancellationToken cancellationToken)
    {
        if (request.ShoppingCartList == null!) return await Task.FromResult(false);

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
            SuccessUrl = "http://localhost:5173/success",
            CancelUrl = "http://localhost:5173/failed",
        };

        var service = new SessionService();
        var session = await service.CreateAsync(options, cancellationToken: cancellationToken);
        return await Task.FromResult(session != null);
    }
}
