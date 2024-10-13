namespace Backend.Application.Dtos.Payment
{
    public class CardDetailsDto
    {
        public required string CardNumber { get; set; }
        public required string ExpiredDate { get; set; }
        public required string CardHolderName { get; set; }
        public required string Cvv { get; set; }
    }
}