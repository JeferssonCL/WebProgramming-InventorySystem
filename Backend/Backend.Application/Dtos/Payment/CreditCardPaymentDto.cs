namespace Backend.Application.Dtos.Payment
{
    public class CreditCardPaymentDto : PaymentMethodDto
    {
        public CardDetailsDto? CardDetails { get; set; }
    }
}