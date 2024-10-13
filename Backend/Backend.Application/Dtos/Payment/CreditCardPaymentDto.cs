namespace Backend.Application.Dtos
{
    public class CreditCardPaymentDto : PaymentMethodDto
    {
        public CardDetailsDto? CardDetails { get; set; }
    }
}