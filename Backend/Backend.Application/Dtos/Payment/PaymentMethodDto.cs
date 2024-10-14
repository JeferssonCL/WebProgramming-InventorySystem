using Backend.Domain.Entities.Enums;

namespace Backend.Application.Dtos
{
    public abstract class PaymentMethodDto
    {
        public PaymentMethod PaymentMethod { get; set; }
    }
}